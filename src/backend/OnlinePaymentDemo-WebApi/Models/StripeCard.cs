namespace OnlinePaymentDemo_WebApi.Models
{
    public class StripeCard
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationMonth { get; set; }
        public string? ExprationYear { get; set; }
        public string? CVC { get; set; }
    }
}
