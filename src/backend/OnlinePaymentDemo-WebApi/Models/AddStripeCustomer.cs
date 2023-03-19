namespace OnlinePaymentDemo_WebApi.Models
{
    public record AddStripeCustomer(
        string Email,
        string Name,
        AddStripeCard CreditCard);   
}
