using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseRegister.Models
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }
        public ParttimeStudent(string name) : base(name) { }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            if (selectedCourses.Count <= MaxNumOfCourses)
            {
                base.RegisterCourses(selectedCourses);
            }
            else
            {
                throw new Exception("Parttime students can not exceed " + MaxNumOfCourses + " courses per week.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + " (Part time)";
        }
    }
}