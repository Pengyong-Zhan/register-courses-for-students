using CourseRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseRegister
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["students"] == null)
            {
                TableRow fisrtRow = new TableRow();
                tblStudents.Rows.Add(fisrtRow);

                TableCell cell = new TableCell();
                fisrtRow.Cells.Add(cell);
                cell.ColumnSpan = 2;
                cell.Text = "No Student Yet";
                cell.HorizontalAlign = HorizontalAlign.Center;
            }
            else if (!IsPostBack && Session["students"] != null)
            {
                List<Student> students = new List<Student>();
                students = (List<Student>)Session["students"];
                foreach (Student s in students)
                {
                    TableRow rowNew = new TableRow();
                    tblStudents.Rows.Add(rowNew);

                    TableCell cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = s.Id.ToString();

                    cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = s.Name;
                }

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            List<Student> students = new List<Student>();
            if (Session["students"] != null)
            {
                students = (List<Student>)Session["students"];
            }
            else
            {
                tblStudents.Rows.Remove(tblStudents.Rows[1]);
            }

            if (drpStuType.SelectedIndex != -1 && !string.IsNullOrEmpty(txtStuName.Text))
            {
                if (drpStuType.SelectedValue == "FulltimeStudent")
                {
                    Student newStudent = new FulltimeStudent(txtStuName.Text);
                    students.Add(newStudent);//errmsg: students was null
                }

                if (drpStuType.SelectedValue == "ParttimeStudent")
                {
                    Student newStudent = new ParttimeStudent(txtStuName.Text);
                    students.Add(newStudent);
                }

                if (drpStuType.SelectedValue == "CoopStudent")
                {
                    Student newStudent = new CoopStudent(txtStuName.Text);
                    students.Add(newStudent);
                }

                Session["students"] = students;

            }
            foreach (Student s in students)
            {
                TableRow rowNew = new TableRow();
                tblStudents.Rows.Add(rowNew);

                TableCell cell = new TableCell();
                rowNew.Cells.Add(cell);
                cell.Text = s.Id.ToString();

                cell = new TableCell();
                rowNew.Cells.Add(cell);
                cell.Text = s.Name;
            }
        }
    }
}