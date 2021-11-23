

using Domain.Interfaces;

namespace Domain
{
    public class ExpenceDatail : IEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenceHeader ExpenceHeader { get; set; }
        public User User { get; set; }
    }

}

