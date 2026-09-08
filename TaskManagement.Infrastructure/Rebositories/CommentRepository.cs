using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, IComment
    {
        private readonly AppDbContext context;

        public CommentRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
