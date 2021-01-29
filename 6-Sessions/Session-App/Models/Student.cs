using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session_App.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set;}
    }
}
