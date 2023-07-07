using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Train_D.DTO.Stripe;
using Train_D.Models.Stripe;
using Train_D.Services;
using Train_D.Services.Contract;

namespace Train_D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : Controller
    {
        private readonly IStripeAppService _stripeService;
        private readonly ITicketService _ticketService;

        public StripeController(IStripeAppService stripeService, ITicketService ticketService)
        {
            _stripeService = stripeService;
            _ticketService = ticketService;
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


        [HttpGet ("GetpaymentId/{tickentId}")]
        public async Task<IActionResult> GetPaymentId([FromRoute] int tickentId)
        {
            var paymentId = await _ticketService.GetPaymentId(tickentId);
            
            if(paymentId is null)
                return BadRequest(new {Message = "Ticket Id is Incorrect" });
            
            return Ok(paymentId);
        }


        [HttpPost("refund")]
        public async Task<IActionResult> Refund([FromBody] RefundRequestModel refundRequest)
        {
            if (refundRequest.date.Date < DateTime.Now)
                return BadRequest(new { Message = "can't cancel a ticket if trip is today" });

            var refundResult = await _stripeService.Refund(refundRequest.PaymentId, refundRequest.Amount);

            return (refundResult.Success ? Ok(new { Message = refundResult.Message }) : BadRequest( new { Message = refundResult.Message }));
        }
    }
}
