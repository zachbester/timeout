using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> ProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> ProductsAsync();
        Task<IReadOnlyList<ProductBrand>> ProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> ProductTypesAsync();
    }
}