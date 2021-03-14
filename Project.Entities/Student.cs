using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Student:IEntity
    {
        public int StudentId { get; set; }
        public int StudentNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int StatusOfStudent { get; set; }
        public virtual IList<StudentCourse> StudentCourses { get; set; }

    }
}
