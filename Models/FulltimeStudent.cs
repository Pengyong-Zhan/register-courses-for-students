using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseRegister.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public FulltimeStudent(string name) : base(name) { }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            if (TotalWeeklyHours(selectedCourses) <= MaxWeeklyHours)
            {
                base.RegisterCourses(selectedCourses);
            }
            else
            {
                throw new Exception("Fulltime students can not exceed " + MaxWeeklyHours + " hours per week.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + " (Full time)";
        }
    }
}