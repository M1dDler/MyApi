using Ardalis.Specification;
using Domain;
using System.Linq;

namespace BusinessLogic.Specifications
{
    public class ExpenceByIdSpecification : Specification<ExpenceDatail>
    {
        public ExpenceByIdSpecification(int id)
        {
            Query.Where(x => x.Id == id)
                .Include(y => y.ExpenceHeader);
        }
    }

}
