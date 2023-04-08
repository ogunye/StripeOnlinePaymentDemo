using Microsoft.EntityFrameworkCore;
using OnlinePaymentDemo_WebApi.Models;

namespace OnlinePaymentDemo_WebApi.Data
{
    public class DataContextDb : DbContext
    {
        public DataContextDb(DbContextOptions<DataContextDb> options) : base(options)
        {
            
        }

        public DbSet<CCustomer> Customers { get; set; }
        public DbSet<StripeCard> StripeCards { get; set; }
        //public DbSet<StripePayment> StripePayments { get; set; }       
    }
}
