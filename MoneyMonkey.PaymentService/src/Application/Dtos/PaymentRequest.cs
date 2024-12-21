namespace MoneyMonkey.PaymentService.Application.Dtos
{
    public record PaymentRequest(decimal Amount, string Currency, string Method);
}