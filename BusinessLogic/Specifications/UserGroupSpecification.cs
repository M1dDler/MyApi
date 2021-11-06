using System.Linq;
using Ardalis.Specification;
using Domain;

namespace BusinessLogic.Specifications
{
    public class UserInGroupByIdSpecification : Specification<Group>
    {
        public UserInGroupByIdSpecification(int groupId)
        {
            Query.Where(x => x.Id == groupId)
                .Include(y => y.User);
        }
    }

}
