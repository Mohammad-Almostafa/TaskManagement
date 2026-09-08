using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProject
    {
        private readonly AppDbContext context;

        public ProjectRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
