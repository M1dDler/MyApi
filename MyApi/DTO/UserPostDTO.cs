using System.Collections.Generic;

namespace MyApi.DTO
{
    public class UserPostDTO
    {
        public string Name { get; set; }
        public List<int> GroupsId { get; set; }
    }
}

