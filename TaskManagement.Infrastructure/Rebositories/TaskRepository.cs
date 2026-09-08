using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : GenericRepository<Domain.Entities.Task>, ITask
    {
        private readonly AppDbContext context;

        public TaskRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
