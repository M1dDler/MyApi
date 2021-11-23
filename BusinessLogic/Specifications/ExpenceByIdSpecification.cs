using Ardalis.Specification;
using Domain;
using System.Linq;

namespace BusinessLogic.Specifications
{
    public class ExpenceByIdSpecification : Specification<ExpenceHeader>
    {
        public ExpenceByIdSpecification(int id)
        {
            Query.Where(x => x.Id == id)
                .Include(y => y.ExpenceDatails);
        }
    }

}
