namespace Train_D.DTO.Stripe
{
    public class RefundRequestModel
    {
        public string PaymentId { get; set; }
        public int Amount { get; set; }
    }
}
