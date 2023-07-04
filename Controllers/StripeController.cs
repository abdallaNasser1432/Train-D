using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Train_D.DTO.Stripe;
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
        public async Task<IActionResult> AddStripeCustomer([FromBody] AddStripeCustomer customer, CancellationToken ct)
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
        public async Task<IActionResult> AddStripePayment([FromBody] AddStripePayment payment, CancellationToken ct)
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

        [HttpPost("refund")]
        public async Task<IActionResult> Refund([FromBody] RefundRequestModel refundRequest)
        {
            var refundResult = await _stripeService.Refund(refundRequest.PaymentId, refundRequest.Amount);

            return (refundResult.Success ? Ok(new { Message = refundResult.Message }) : BadRequest( new { Message = refundResult.Message }));
        }
    }
}
