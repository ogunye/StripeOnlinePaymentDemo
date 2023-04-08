using System.ComponentModel.DataAnnotations;

namespace OnlinePaymentDemo_WebApi.Models
{
    public class CCustomer
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
