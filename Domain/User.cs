using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
    }
}
