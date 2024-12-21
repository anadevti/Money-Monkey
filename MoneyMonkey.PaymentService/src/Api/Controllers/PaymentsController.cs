using Microsoft.AspNetCore.Mvc;
using MoneyMonkey.PaymentService.Application.Dtos;
using MoneyMonkey.PaymentService.Application.Services;

namespace MoneyMonkey.PaymentService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult CreatePayment([FromBody] PaymentRequest request)
        {
            var response = _paymentService.CreatePayment(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentStatus([FromRoute] string id)
        {
            var response = _paymentService.GetPayment(id);
            return response is not null ? Ok(response) : NotFound();
        }
    }
}