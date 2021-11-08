using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using DataAccess.Interfaces;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BusinessLogic.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IBaseRepository<Payment> _repository;

        public PaymentService(IBaseRepository<Payment> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await _repository.GetAsync();
        }
        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            var specification = new PaymentSpecification(id);
            var item = await _repository.GetSingleAsync(specification);

            return item;
        }
        public async Task<IEnumerable<Payment>> GetPaymentsByIssuerAsync(int id)
        {
            var specification = new PaymentsByIssuerIdSpecification(id);
            var item = await _repository.GetAsync(specification);

            return item;
        }
        public async Task<IEnumerable<Payment>> GetPaymentsByRecipientAsync(int id)
        {
            var specification = new PaymentsByRecipientIdSpecification(id);
            var item = await _repository.GetAsync(specification);

            return item;
        }
        public async Task<IEnumerable<Payment>> GetPaymentsByGroupAsync(int id)
        {
            var specification = new PaymentsByGroupIdSpecification(id);
            var item = await _repository.GetAsync(specification);

            return item;
        }
    }

}
