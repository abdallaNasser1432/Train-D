using Train_D.DTO.Stripe;
using Train_D.Models.Stripe;

namespace Train_D.Services
{
    public interface IStripeAppService
    {
        Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
        Task<RefundCheckDto> Refund(string chargeId, int amount);
    }

}
