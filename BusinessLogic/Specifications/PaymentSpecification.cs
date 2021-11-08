using Ardalis.Specification;
using Domain;
using System.Linq;

namespace BusinessLogic.Specifications
{
    public class PaymentSpecification : Specification<Payment>
    {
        public PaymentSpecification(int id)
        {
            Query.Where(x => x.Id == id);
        }
    }

}
