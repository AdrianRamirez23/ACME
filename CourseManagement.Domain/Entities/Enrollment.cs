using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Entities
{
    public class Enrollment
    {
        public Student Student { get; }
        public Course Course { get; }
        public DateTime EnrollmentDate { get; }

        public Enrollment(Student student, Course course)
        {
            Student = student;
            Course = course;
            EnrollmentDate = DateTime.UtcNow;
        }
    }
}
