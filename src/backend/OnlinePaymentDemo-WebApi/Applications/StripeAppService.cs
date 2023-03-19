using OnlinePaymentDemo_WebApi.Contracts;
using OnlinePaymentDemo_WebApi.Models;
using Stripe;

namespace OnlinePaymentDemo_WebApi.Applications
{
    public class StripeAppService : IStripeAppService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;

        public StripeAppService(ChargeService chargeService, 
            CustomerService customerService,
            TokenService tokenService)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
        }
        public async Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct)
        {
            //Set Stripe Token options based on customer data
            TokenCreateOptions options = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = customer.Name,
                    Number = customer.CreditCard.CardNumber,
                    ExpYear = customer.CreditCard.ExprationYear,
                    ExpMonth = customer.CreditCard.ExpirationMonth,
                    Cvc = customer.CreditCard.CVC
                }
            };

            //Create new Stripe Token
            Token stripeToken = await _tokenService.CreateAsync(options, null, ct);

            //Set Customer options using 
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = customer.Name,
                Email = customer.Email,
                Source = stripeToken.Id
            };

            //Create customer at Stripe

            Customer createCustomer = await _customerService.CreateAsync(customerOptions, null, ct);

            return new StripeCustomer(createCustomer.Name, createCustomer.Email, createCustomer.Id);
        }

        public async Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct)
        {
            //Set the options for the payment we would like to create at Stripe
            ChargeCreateOptions paymentOptions = new ChargeCreateOptions
            {
                Customer = payment.CustomerId,
                ReceiptEmail = payment.ReceiptEmail,
                Description = payment.Description,
                Currency = payment.Currency,
                Amount = payment.Amount,
            };

            //Create the Payment 
            var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);

            return new StripePayment(
                createdPayment.CustomerId,
                createdPayment.ReceiptEmail,
                createdPayment.Description,
                createdPayment.Currency,
                createdPayment.Amount,
                createdPayment.Id);
        }
    }
}
