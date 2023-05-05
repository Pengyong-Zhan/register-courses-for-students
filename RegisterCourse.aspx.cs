using CourseRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseRegister
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                if (Session["students"] == null)
                {
                    Response.Redirect("AddStudent.aspx");
                }
                else
                {
                    foreach (Student student in (List<Student>)Session["students"])
                    {
                        drpStudents.Items.Add(student.ToString());
                    }
                }

                foreach (Course c in Helper.GetAvailableCourses())
                {
                    string unit = c.WeeklyHours > 1 ? "hours" : "hour";
                    chkCoursesAvailable.Items.Add(new ListItem(string.Format("{0} {1} - {2} {3} per week", c.Code, c.Title, c.WeeklyHours.ToString(), unit), c.Code));
                }
            }

        }
        List<Course> tryRegisteredcourses = new List<Course>();
        protected void StudentSelectChange(object sender, EventArgs e)
        {
            List<Student> students = (List<Student>)Session["students"];
            Student studentSelected = null;
            if (drpStudents.SelectedValue != "-1")
            {
                pnlSummary.Visible = true;
                lblSummayCourseNum.Text = "0";
                lblSummayTotalHours.Text = "0";


                int index = drpStudents.SelectedIndex - 1;
                studentSelected = students[index];

                foreach (ListItem listItem in chkCoursesAvailable.Items)
                {
                    listItem.Selected = false;
                }

                if (Session[studentSelected.Name] != null)
                {
                    foreach (ListItem listItem in chkCoursesAvailable.Items)
                    {
                        foreach (Course registered in (List<Course>)Session[studentSelected.Name])
                        {
                            if (listItem.Value == registered.Code)
                            {
                                listItem.Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (ListItem listItem in chkCoursesAvailable.Items)
                    {
                        listItem.Selected = false;
                    }

                }
            }
        }

        protected void CourseSelectChange(object sender, EventArgs e)
        {
            if (drpStudents.SelectedValue != "-1")
            {
                pnlSummary.Visible = true;
                int selectedHours = 0;
                int selectedCourses = 0;
                foreach (ListItem lstItem in chkCoursesAvailable.Items)
                {
                    if (lstItem.Selected)
                    {
                        Course course = Helper.GetCourseByCode(lstItem.Value);
                        selectedHours += course.WeeklyHours;
                        selectedCourses++;
                        tryRegisteredcourses.Add(course);
                    }
                }
                lblSummayCourseNum.Text = selectedCourses.ToString();
                lblSummayTotalHours.Text = selectedHours.ToString();

                if (lblErrorMsg.Visible)
                {
                    List<Student> students = (List<Student>)Session["students"];
                    int index = drpStudents.SelectedIndex - 1;

                    Student studentSelected = students[index];

                    List<Course> courseTrySelected = new List<Course>();
                    foreach (ListItem lstItem in chkCoursesAvailable.Items)
                    {
                        if (lstItem.Selected)
                        {
                            Course c = Helper.GetCourseByCode(lstItem.Value);
                            courseTrySelected.Add(c);
                        }
                    }

                    try
                    {
                        studentSelected.RegisterCourses(courseTrySelected);
                        lblErrorMsg.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        pnlSummary.Visible = false;
                        lblErrorMsg.Visible = true;
                        lblErrorMsg.Text = ex.Message;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                List<Student> students = (List<Student>)Session["students"];
                int index = drpStudents.SelectedIndex - 1;

                Student studentSelected = students[index];

                List<Course> courseTrySelected = new List<Course>();
                int countCourses = 0;
                foreach (ListItem lstItem in chkCoursesAvailable.Items)
                {
                    if (lstItem.Selected)
                    {
                        countCourses++;
                        Course c = Helper.GetCourseByCode(lstItem.Value);
                        courseTrySelected.Add(c);
                    }
                }

                if (countCourses == 0)
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "You need select at least one";
                }

                try
                {
                    studentSelected.RegisterCourses(courseTrySelected);
                    Session[studentSelected.Name] = courseTrySelected;
                }
                catch (Exception ex)
                {
                    pnlSummary.Visible = false;
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = ex.Message;
                }
            }
        }
    }
}