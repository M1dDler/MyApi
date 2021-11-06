using Microsoft.EntityFrameworkCore;
using Ardalis.Specification.EntityFrameworkCore;
using Ardalis.Specification;
using DataAccess.Interfaces;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;

namespace PaymentsList.DataAccess.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        private readonly MyApiDbContext _context;

        public IUnitWork UnitWork => _context;

        public BaseRepository(MyApiDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _context.Set<T>()
                .ToListAsync();
        }

        public async Task<T> InsertASync(T item)
        {
            var inserted = await _context.AddAsync(item);
            return inserted.Entity;
        }

        public Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public async Task DeleteAsync(int id)
        {
            var item = await _context.Set<T>().FirstAsync(x => x.Id == id);
            _context.Remove(item);
        }

        public async Task<IEnumerable<T>> GetAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<T> GetSingleAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_context.Set<T>(), specification);
        }
    }
}
