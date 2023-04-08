using OnlinePaymentDemo_WebApi.Models;

namespace OnlinePaymentDemo_WebApi.Contract
{
    public interface IRepository
    {
        Task CreateCustomer(CCustomer cCustomer);
    }
}
