using Ardalis.Specification;
using Domain;

namespace BusinessLogic.Specifications
{
    public class PaymentsByGroupIdSpecification : Specification<Payment>
    {
        public PaymentsByGroupIdSpecification(int id)
        {
            Query.Include(x => x.Group.Id == id);
        }
    }

}
