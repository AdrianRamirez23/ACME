using CourseManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.PaymentGateway
{
    public class FakePaymentService: IPaymentService
    {
        public bool ProcessPayment(decimal amount)
        {
            return amount > 0; // Simula éxito si el monto es positivo
        }
    }
}
