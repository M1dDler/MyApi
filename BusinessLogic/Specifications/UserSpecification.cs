using Domain;
using Ardalis.Specification;

namespace BusinessLogic.Specifications
{
    public class UserSpecification : Specification<User>
    {
        public UserSpecification(int id)
        {
            Query.Where(x => x.Id == id);
        }
    }

}
