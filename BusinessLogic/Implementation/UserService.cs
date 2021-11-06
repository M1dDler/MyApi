using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using DataAccess.Interfaces;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;
        public UserService(IBaseRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<User> GetUserWithIdAsync(int id)
        {
            var specification = new UserSpecification(id);
            var item = await _repository.GetSingleAsync(specification);

            return item;
        }
    }

}
