using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        IUnitWork UnitWork { get; }
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAsync();
        Task<T> InsertASync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAsync(ISpecification<T> specification);
        Task<T> GetSingleAsync(ISpecification<T> specification);
    }

}
