using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ForMember(p => p.ProductBrand, o => o.MapFrom(b => b.ProductBrand.Name))
                                            .ForMember(p => p.ProductType, o => o.MapFrom(t => t.ProductType.Name))
                                            .ForMember(p => p.ImageUrl, o => o.MapFrom<MappingProductUrlResolver>());
        }
    }
}