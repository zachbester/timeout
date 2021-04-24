using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : Base
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityBySpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllEntitiesBySpec(ISpecification<T> spec);
    }
}