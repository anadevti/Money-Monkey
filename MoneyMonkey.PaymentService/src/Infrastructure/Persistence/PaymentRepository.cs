using MoneyMonkey.PaymentService.Domain.Entities;

namespace MoneyMonkey.PaymentService.Infrastructure.Persistence
{
    public class PaymentRepository : IPaymentRepository
    {
        // Nesta versão inicial, guardamos em memória. irei ajustar depois para DynamoDB.
        private static readonly Dictionary<string, Payment> _payments = new();

        public void Save(Payment payment)
        {
            _payments[payment.PaymentId] = payment;
        }

        public Payment? GetById(string paymentId)
        {
            _payments.TryGetValue(paymentId, out var payment);
            return payment;
        }
    }
}