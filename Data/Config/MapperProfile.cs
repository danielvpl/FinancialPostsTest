using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Data.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Financial, FinancialResponse>();                
        }
    }
}
