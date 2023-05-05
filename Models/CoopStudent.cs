using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseRegister.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }
        public CoopStudent(string name) : base(name) { }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            if (selectedCourses.Count <= MaxNumOfCourses && TotalWeeklyHours(selectedCourses) <= MaxWeeklyHours)
            {
                base.RegisterCourses(selectedCourses);
            }
            else
            {
                throw new Exception("Coop students can not exceed " + MaxNumOfCourses + " courses per week, and can not exceed " + MaxWeeklyHours + " hours per week.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + " (Coop)";
        }
    }
}