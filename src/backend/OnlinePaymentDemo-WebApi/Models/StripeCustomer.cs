namespace OnlinePaymentDemo_WebApi.Models
{
    public record StripeCustomer(
        string CustomerId,
        string Name,
        string Email);
}
