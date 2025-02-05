using CourseManagement.Infrastructure.PaymentGateway;

namespace CourseManagement.Tests.Infrastructure.Test
{
    public class FakePaymentServiceTests
    {
        [Fact]
        public void Should_Return_True_For_Positive_Payment()
        {
            var service = new FakePaymentService();
            bool result = service.ProcessPayment(100);
            Assert.True(result);
        }

        [Fact]
        public void Should_Return_False_For_Zero_Or_Negative_Payment()
        {
            var service = new FakePaymentService();
            bool result = service.ProcessPayment(0);
            Assert.False(result);
        }
    }
}