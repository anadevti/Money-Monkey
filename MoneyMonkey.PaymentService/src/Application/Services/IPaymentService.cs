using MoneyMonkey.PaymentService.Application.Dtos;

namespace MoneyMonkey.PaymentService.Application.Services
{
    public interface IPaymentService
    {
        PaymentResponse CreatePayment(PaymentRequest request);
        PaymentResponse? GetPayment(string paymentId);
    }
}