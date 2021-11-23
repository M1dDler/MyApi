using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using DataAccess.Interfaces;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation
{
    public class ExpenceService : IExpenceService
    {
        private readonly IBaseRepository<ExpenceHeader> _repository;
        public ExpenceService(IBaseRepository<ExpenceHeader> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ExpenceHeader>> GetExpencesAsync()
        {
            return await _repository.GetAsync();
        }
        public async Task<ExpenceHeader> GetExpenceByIdAsync(int id)
        {
            var specification = new ExpenceByIdSpecification(id);
            var item = await _repository.GetSingleAsync(specification);

            return item;
        }

        public async Task CreateExpence(ExpenceHeader expenceHeader)
        {
            await _repository.InsertASync(expenceHeader);
            await _repository.UnitWork.CommitAsync();
        }
    }


}
