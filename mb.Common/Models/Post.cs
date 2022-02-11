using System;
using System.ComponentModel.DataAnnotations;

namespace mb.Common.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public string FilePath { get; set; }

        public Post()
        {
            
        }

        public Post(string firstName, string lastName, string email, string text, string filePath)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Text = text;
            FilePath = filePath;
        }
    }
}