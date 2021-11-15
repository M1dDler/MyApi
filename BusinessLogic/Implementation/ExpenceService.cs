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
        private readonly IBaseRepository<ExpenceDatail> _repository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Group> _groupRepository;
        public ExpenceService(IBaseRepository<ExpenceDatail> repository, IBaseRepository<User> userRepository, IBaseRepository<Group> groupRepository)
        {
            _repository = repository;
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<ExpenceDatail>> GetExpencesAsync()
        {
            return await _repository.GetAsync();
        }
        public async Task<ExpenceDatail> GetExpenceByIdAsync(int id)
        {
            var specification = new ExpenceByIdSpecification(id);
            var item = await _repository.GetSingleAsync(specification);

            return item;
        }

        public async Task CreateExpence(/*ExpenceHeader expenceHeader, List<ExpenceDetail> expenceDatails*/)
        {
            
        }
    }

}
