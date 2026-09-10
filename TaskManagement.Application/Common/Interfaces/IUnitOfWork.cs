namespace TaskManagement.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // نقوم هنا بتعريف الـ Repositories التي يضمها المشرف العام
        IProject Projects { get; }
        IComment Comments { get; }
        ITask Tasks { get; }

        // الدالة الموحدة لحفظ جميع التغييرات في خطوة واحدة بالـ Database
        Task<int> CompleteAsync();
    }
}