using AutoMapper;
using DomainModel.Entities;

namespace Application.Mapping
{
    internal class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<PricesHeader, Shared.Dtos.Root>().ReverseMap();
            CreateMap<PricesDetail, Shared.Dtos.Price>().ReverseMap();
        }


    }
}

