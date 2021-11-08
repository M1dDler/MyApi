using System.Linq;
using Ardalis.Specification;
using Domain;

namespace BusinessLogic.Specifications
{
        public class GroupIdSpecification : Specification<Group>
        {
            public GroupIdSpecification(int id)
            {
                Query.Where(x => x.Id == id);   
            }
        }
}
