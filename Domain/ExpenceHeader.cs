using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain
{
    public class ExpenceHeader : IEntity
    {
        public int Id { get; set; }
        public string Descrption { get; set; }
        public List<ExpenceDatail> ExpenceDatails { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }

}

