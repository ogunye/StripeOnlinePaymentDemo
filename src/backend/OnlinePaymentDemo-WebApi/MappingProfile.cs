using AutoMapper;
using OnlinePaymentDemo_WebApi.DTOs;
using OnlinePaymentDemo_WebApi.Models;

namespace OnlinePaymentDemo_WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerDto, CCustomer>();
        
        }
    }
}
