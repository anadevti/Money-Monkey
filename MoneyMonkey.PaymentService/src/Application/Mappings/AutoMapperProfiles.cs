using AutoMapper;
using MoneyMonkey.PaymentService.Application.Dtos;
using MoneyMonkey.PaymentService.Domain.Entities;

namespace MoneyMonkey.PaymentService.Application.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Payment, PaymentResponse>();
        }
    }
}