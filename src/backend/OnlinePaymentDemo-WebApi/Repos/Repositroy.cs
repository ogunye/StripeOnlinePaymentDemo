using OnlinePaymentDemo_WebApi.Contract;
using OnlinePaymentDemo_WebApi.Data;
using OnlinePaymentDemo_WebApi.Models;

namespace OnlinePaymentDemo_WebApi.Repos
{
    public class Repositroy : IRepository
    {
        private readonly DataContextDb _dataContext;

        public Repositroy(DataContextDb dataContext)
        {
            _dataContext = dataContext;
        }
        public Task CreateCustomer(CCustomer cCustomer)
        {
           var customerEntity =  _dataContext.AddAsync(cCustomer);
          return  _dataContext.SaveChangesAsync();
        }
    }
}
