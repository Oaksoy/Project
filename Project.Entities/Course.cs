using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Course : IEntity
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }
        public int StatusOfCourse { get; set; }
        public virtual IList<StudentCourse> StudentCourses { get; set; }

    }
}
