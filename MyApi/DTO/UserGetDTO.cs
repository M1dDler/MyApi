using System.Collections.Generic;

namespace MyApi.DTO
{
    public class UserGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Groups { get; set; }
    }
}

