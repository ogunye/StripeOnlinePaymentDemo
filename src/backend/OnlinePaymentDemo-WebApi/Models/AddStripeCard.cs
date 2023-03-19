namespace OnlinePaymentDemo_WebApi.Models
{
    public record AddStripeCard(
        string Name,
        string CardNumber,
        string ExpirationMonth,
        string ExprationYear,
        string CVC
        );
}
