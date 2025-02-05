using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Entities
{
    public class PaymentTransaction
    {
        public Student Student { get; }
        public Course Course { get; }
        public decimal Amount { get; }
        public DateTime PaymentDate { get; }

        public PaymentTransaction(Student student, Course course, decimal amount)
        {
            Student = student;
            Course = course;
            Amount = amount;
            PaymentDate = DateTime.UtcNow;
        }
    }
}
