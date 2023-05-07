using Microsoft.AspNetCore.Mvc;
using Train_D.Models.Stripe;
using Train_D.Services;

namespace Train_D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : Controller
    {
        private readonly IStripeAppService _stripeService;

        public StripeController(IStripeAppService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("customer/add")]
        public async Task<ActionResult<StripeCustomer>> AddStripeCustomer([FromBody] AddStripeCustomer customer, CancellationToken ct)
        {
            try
            {
                StripeCustomer createdCustomer = await _stripeService.AddStripeCustomerAsync(customer, ct);
                return Ok(createdCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("payment/add")]
        public async Task<ActionResult<StripePayment>> AddStripePayment([FromBody] AddStripePayment payment, CancellationToken ct)
        {
            try
            {
                StripePayment createdPayment = await _stripeService.AddStripePaymentAsync(payment, ct);
                return Ok(new { Message = "Reservation successful", createdPayment.PaymentId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
