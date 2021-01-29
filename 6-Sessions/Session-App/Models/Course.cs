using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session_App.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
