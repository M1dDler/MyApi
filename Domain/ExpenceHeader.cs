using Domain;
using System;
using System.Collections.Generic;


namespace Domain
{
    public class ExpenceHeader
    {
        public int Id { get; set; }
        public string Descrption { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int GroupId { get; set; }
        public Group Groups { get; set; }
    }
}

