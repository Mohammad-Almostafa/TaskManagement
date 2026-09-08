using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        // قراءة فقط (Read-only properties) للـ Repositories
        public ITask Tasks { get; private set; }
        public IProject Projects { get; private set; }
        public IComment Comments { get; private set; }

        // نقوم بحقن الـ ApplicationDbContext ليتشاركه جميع الـ Repositories
        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            // تهيئة الـ Repositories وتمرير الـ Context المشترك لها
            
            Comments = new CommentRepository(_context);
            Projects = new ProjectRepository(_context);
            Tasks = new TaskRepository(_context);
        }


        // استدعاء الحفظ الفعلي لـ Entity Framework مرة واحدة
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // تفريغ الـ Context من الذاكرة بأمان عند انتهاء الطلب (Request)
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}