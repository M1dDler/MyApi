using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using BusinessLogic.Exceptions;
using DataAccess.Interfaces;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IBaseRepository<Group> _repository;
        private readonly IBaseRepository<User> _userRepository;
        public GroupService(IBaseRepository<Group> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task AddUserToGroupAsync(int groupId, int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var group = await _repository.GetByIdAsync(groupId);
            if (user == null)
            {
                throw new NotFoundUserException();
            }
            var specification = new UserInGroupByIdSpecification(groupId);
            var usersInGroup = await _repository.GetSingleAsync(specification);

            if (!usersInGroup.User.Any(x => x.Id == userId))
            {
                throw new IsUserInGroup();
            }
            group.User.Add(user);
            await _repository.UpdateAsync(group);
            await _repository.UnitWork.CommitAsync();
        }

        public async Task CompleteGroupAsync(int id)
        {
            var Item = await _repository.GetByIdAsync(id);

            if (Item is null)
            {
                throw new System.Exception();
            }

            Item.isCompleted = true;
            await _repository.UpdateAsync(Item);
            await _repository.UnitWork.CommitAsync();
        }
    }
}
