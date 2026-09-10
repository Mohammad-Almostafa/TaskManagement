using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🚀 يقرأ ويطبق كل الكلاسات التي تتطابق مع IEntityTypeConfiguration تلقائياً
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static async System.Threading.Tasks.Task CreateInitialDbData(AppDbContext _context)
        {

            //await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
        }

        public DbSet<Domain.Entities.Task> Tasks => Set<Domain.Entities.Task>();

        public DbSet<Project> Projects => Set<Project>();

        public DbSet<Comment> Comments => Set<Comment>();
    }
}
