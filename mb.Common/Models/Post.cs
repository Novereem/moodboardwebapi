using System;
using System.ComponentModel.DataAnnotations;

namespace mb.Common.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Account { get; set; }
        public string Text { get; set; }
        public string FilePath { get; set; }
        

        public Post()
        {
            
        }

        public Post(string account, string text, string filePath)
        {
            Id = Guid.NewGuid();
            Account = account;
            Text = text;
            FilePath = filePath;
        }
    }
}