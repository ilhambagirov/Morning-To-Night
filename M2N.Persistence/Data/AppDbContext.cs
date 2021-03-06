using M2N.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace M2N.Persistence.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskCategory> TaskCategories { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<AppTask> Tasks { get; set; }
        public object FirstOrDefaultAsnyc { get; set; }
    }
}
