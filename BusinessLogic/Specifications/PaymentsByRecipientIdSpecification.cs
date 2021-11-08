using Ardalis.Specification;
using Domain;

namespace BusinessLogic.Specifications
{
    public class PaymentsByRecipientIdSpecification : Specification<Payment>
    {
        public PaymentsByRecipientIdSpecification(int id)
        {
            Query.Include(x => x.Recipient.Id == id);
        }
    }
}
