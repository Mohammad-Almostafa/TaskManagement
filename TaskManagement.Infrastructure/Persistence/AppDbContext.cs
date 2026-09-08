using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {  }

        public DbSet<Domain.Entities.Task> Tasks => Set<Domain.Entities.Task>();

        public DbSet<Project> Projects => Set<Project>();

        public DbSet<Comment> Comments => Set<Comment>();
    }
}
