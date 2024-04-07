using Microsoft.EntityFrameworkCore;
using NostaleLauncher.Domain.Entities;

namespace NostaleLauncher.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}