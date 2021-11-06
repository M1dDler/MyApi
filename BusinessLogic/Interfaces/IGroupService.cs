using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroupsAsync();
        Task AddUserToGroupAsync(int groupId, int userId);
    }
}
