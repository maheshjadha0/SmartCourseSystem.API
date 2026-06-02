using SmartCourseSystem.API.Models;

namespace SmartCourseSystem.API.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>>
            GetAllAsync();

        Task<Enrollment?>
            GetByIdAsync(int id);

        Task<bool>
            IsAlreadyPurchasedAsync(
                int userId,
                int courseId);

        Task AddAsync(
            Enrollment enrollment);

        void Delete(
            Enrollment enrollment);

        Task SaveChangesAsync();
    }
}
