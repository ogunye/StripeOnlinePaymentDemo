namespace OnlinePaymentDemo_WebApi.Models
{
    public record StripeCustomer(
        string Name,
        string Email,
        string CustomerId);
}
