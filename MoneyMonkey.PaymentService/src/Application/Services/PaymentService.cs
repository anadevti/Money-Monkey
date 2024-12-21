using MoneyMonkey.PaymentService.Application.Dtos;
using MoneyMonkey.PaymentService.Domain.Entities;
using MoneyMonkey.PaymentService.Domain.Enums;
using MoneyMonkey.PaymentService.Domain.Interfaces;
using AutoMapper;

namespace MoneyMonkey.PaymentService.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentGateway _paymentGateway;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentGateway paymentGateway, IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentGateway = paymentGateway;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public PaymentResponse CreatePayment(PaymentRequest request)
        {
            // Cria entidade de pagamento
            var payment = new Payment
            {
                PaymentId = Guid.NewGuid().ToString("N"),
                Amount = request.Amount,
                Currency = request.Currency,
                Method = request.Method,
                Status = PaymentStatus.Processing,
                Timestamp = DateTime.UtcNow
            };

            // Chama gateway (mock)
            _paymentGateway.Charge(payment);

            // Salva no repositório
            _paymentRepository.Save(payment);

            // Retorna DTO de resposta
            return _mapper.Map<PaymentResponse>(payment);
        }

        public PaymentResponse? GetPayment(string paymentId)
        {
            var payment = _paymentRepository.GetById(paymentId);
            return payment is not null ? _mapper.Map<PaymentResponse>(payment) : null;
        }
    }
}