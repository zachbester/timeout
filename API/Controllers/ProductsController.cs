using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using API.DTOs;
using System.Linq;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<ProductBrand> _brand;
        private readonly IGenericRepository<ProductType> _type;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> product, 
                                  IGenericRepository<ProductBrand> brand,
                                  IGenericRepository<ProductType> type, 
                                  IMapper mapper) 
        {
            _product = product;
            _brand = brand;
            _type = type;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var spec = new ProductsTypesBrandsSpecification();
            var products = await _product.GetAllEntitiesBySpec(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsTypesBrandsSpecification(id);
            var product = await _product.GetEntityBySpec(spec);
            if (product == null)
                return NotFound(new ErrorResponse(404));
            return _mapper.Map<Product, ProductDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _brand.GetAllAsync());
        }        

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _type.GetAllAsync());
        }          
    }
}