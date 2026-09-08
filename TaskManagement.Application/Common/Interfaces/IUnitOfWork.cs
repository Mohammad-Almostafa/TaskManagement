namespace TaskManagement.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // نقوم هنا بتعريف الـ Repositories التي يضمها المشرف العام


        // الدالة الموحدة لحفظ جميع التغييرات في خطوة واحدة بالـ Database
        Task<int> CompleteAsync();
    }
}