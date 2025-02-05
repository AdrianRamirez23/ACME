using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public class EnrollmentService
    {
        private readonly IPaymentService _paymentService;
        private readonly List<Enrollment> _enrollments = new List<Enrollment>();
        private readonly List<PaymentTransaction> _payments = new List<PaymentTransaction>();

        public EnrollmentService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public bool Enroll(Student student, Course course)
        {
            bool paymentSuccess = _paymentService.ProcessPayment(course.RegistrationFee);
            if (!paymentSuccess) return false;

            if (course.RegistrationFee > 0)
            {
                // Registrar pago
                _payments.Add(new PaymentTransaction(student, course, course.RegistrationFee));
            }

            _enrollments.Add(new Enrollment(student, course));
            return true;
        }

        public List<(Course course, List<Student> students)> GetCoursesWithEnrollments(DateTime from, DateTime to)
        {
            return _enrollments
                .Where(e => e.Course.StartDate >= from && e.Course.EndDate <= to)
                .GroupBy(e => e.Course)
                .Select(group => (group.Key, group.Select(e => e.Student).ToList()))
                .ToList();
        }
    }
}
