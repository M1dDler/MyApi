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
        private readonly IBaseRepository<Group> _grouprepository;
        private readonly IBaseRepository<User> _userrepository;

        public GroupService(IBaseRepository<Group> grouprepository, IBaseRepository<User> userrepository)
        {
            _grouprepository = grouprepository;
            _userrepository = userrepository;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await _grouprepository.GetAsync();
        }

        public async Task AddUserToGroupAsync(int groupId, int userId)
        {
            var user = await _userrepository.GetByIdAsync(userId);
            var group = await _grouprepository.GetByIdAsync(groupId);
            if (user == null)
            {
                throw new NotFoundUserException();
            }
            var specification = new UserGroupSpecification(groupId);
            var usersInGroup = await _grouprepository.GetSingleAsync(specification);

            if (!usersInGroup.User.Any(x => x.Id == userId))
            {
                throw new IsUserInGroup();
            }
            group.User.Add(user);
            await _grouprepository.UpdateAsync(group);
            await _grouprepository.UnitWork.CommitAsync();
        }
    }
}
