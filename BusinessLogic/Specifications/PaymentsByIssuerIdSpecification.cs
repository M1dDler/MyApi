using Ardalis.Specification;
using Domain;

namespace BusinessLogic.Specifications
{
    public class PaymentsByIssuerIdSpecification : Specification<Payment>
    {
        public PaymentsByIssuerIdSpecification(int id)
        {
            Query.Include(x => x.Issuer.Id == id);
        }
    }
}
