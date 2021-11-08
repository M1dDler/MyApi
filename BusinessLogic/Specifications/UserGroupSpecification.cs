using System.Linq;
using Ardalis.Specification;
using Domain;

namespace BusinessLogic.Specifications
{
    public class UserGroupSpecification : Specification<Group>
    {
        public UserGroupSpecification(int groupId)
        {
            Query.Where(x => x.Id == groupId)
                .Include(y => y.User);
        }
    }

}
