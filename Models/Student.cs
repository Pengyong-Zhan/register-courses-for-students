using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseRegister.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> RegisteredCourses { get; }
        protected Student(string name)
        {
            Id = new Random().Next(100000, 999999);
            Name = name;
            RegisteredCourses = new List<Course>();
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            RegisteredCourses.AddRange(selectedCourses);

        }

        public int TotalWeeklyHours(List<Course> selectedCourses)
        {
            int sum = selectedCourses.Sum(c => c.WeeklyHours);
            return sum;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Id, Name);
        }
    }
}