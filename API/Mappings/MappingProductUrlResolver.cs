using API.DTOs;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Mappings
{
    public class MappingProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        public IConfiguration _configuration { get; }

        public MappingProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _configuration["APIUrl"] + source.ImageUrl;
            }

            return null;
        }
    }
}