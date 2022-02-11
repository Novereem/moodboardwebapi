using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mb.Common.Models
{
    public class Moodboard
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Account { get; set; }
        public List<Post> Posts { get; set; }

        public Moodboard(string name, string account)
        {
            Id = Guid.NewGuid();
            Name = name;
            Account = account;
            Posts = new List<Post>();
        }
    }
}