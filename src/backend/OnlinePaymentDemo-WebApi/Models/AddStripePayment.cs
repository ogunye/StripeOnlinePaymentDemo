namespace OnlinePaymentDemo_WebApi.Models
{
    public record AddStripePayment(
        string CustomerId,
        string ReceiptEmail,
        string Description, 
        string Currency,
        long Amount);
   
}
