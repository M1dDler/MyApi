using System.Collections.Generic;

namespace Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> User { get; set; }
        public List<Payment> Payments { get; set; }
    }
}

