using Ardalis.Specification;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
