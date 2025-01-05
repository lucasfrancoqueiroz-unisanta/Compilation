using Compilation.Models;
using Microsoft.EntityFrameworkCore;

namespace Compilation
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }
    }
}
