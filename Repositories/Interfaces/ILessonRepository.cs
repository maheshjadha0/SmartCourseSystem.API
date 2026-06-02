using SmartCourseSystem.API.Models;

namespace SmartCourseSystem.API.Repositories.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetAllAsync();

        Task<Lesson?> GetByIdAsync(int id);

        Task AddAsync(Lesson lesson);

        void Update(Lesson lesson);

        void Delete(Lesson lesson);

        Task SaveChangesAsync();
    }
}
