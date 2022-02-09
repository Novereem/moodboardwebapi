using mb.Common;
using mb.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace mb.Data
{
    public class MbContext : DbContext, IMbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Moodboard> Moodboards { get; set; }
        public DbSet<Post> Posts { get; set; }
        
        public MbContext(DbContextOptions<MbContext> options)
            : base(options)
        {
            
        }
    }
}