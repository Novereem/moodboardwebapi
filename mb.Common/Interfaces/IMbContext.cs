using System;
using mb.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace mb.Common
{
    public interface IMbContext : IDbContext, IDisposable
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Moodboard> Moodboards { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}