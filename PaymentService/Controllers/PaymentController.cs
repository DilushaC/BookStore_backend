using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PaymentService.Repositories;
using PaymentService.Models;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _repository;

        public PaymentController(IPaymentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(string id)
        {
            var payment = await _repository.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
        {
            await _repository.CreatePaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id.ToString() }, payment);
        }
    }
}
