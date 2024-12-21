using MoneyMonkey.PaymentService.Domain.Enums;

namespace MoneyMonkey.PaymentService.Domain.Entities
{
    public class Payment
    {
        public string PaymentId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public string Method { get; set; } = "credit_card";
        public PaymentStatus Status { get; set; } = PaymentStatus.Processing;
        public DateTime Timestamp { get; set; }
    }
}