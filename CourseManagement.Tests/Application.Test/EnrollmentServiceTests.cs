using CourseManagement.Application.Services;
using CourseManagement.Domain.Entities;
using CourseManagement.Infrastructure.PaymentGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Tests.Application.Test
{
    public class EnrollmentServiceTests
    {
        [Fact]
        public void Should_Enroll_Student_When_Payment_Successful()
        {
            var student = new Student("John Doe", 20);
            var course = new Course("Math", 100, DateTime.Today, DateTime.Today.AddDays(30));
            var paymentService = new FakePaymentService();
            var enrollmentService = new EnrollmentService(paymentService);

            bool result = enrollmentService.Enroll(student, course);

            Assert.True(result);
        }

        [Fact]
        public void Should_Not_Enroll_Student_When_Payment_Fails()
        {
            var student = new Student("John Doe", 20);
            var course = new Course("Science", -1, DateTime.Today, DateTime.Today.AddDays(30));
            var paymentService = new FakePaymentService();
            var enrollmentService = new EnrollmentService(paymentService);

            bool result = enrollmentService.Enroll(student, course);

            Assert.False(result);
        }
    }
}
