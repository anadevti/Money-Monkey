namespace MoneyMonkey.PaymentService.Application.Dtos
{
    public record PaymentResponse(string PaymentId, string Status, decimal Amount, string Currency, string Method, DateTime Timestamp);
}