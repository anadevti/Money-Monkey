using MoneyMonkey.PaymentService.Domain.Entities;

namespace MoneyMonkey.PaymentService.Domain.Interfaces
{
    public interface IPaymentGateway
    {
        void Charge(Payment payment);
        void Refund(Payment payment, decimal amount);
    }
}