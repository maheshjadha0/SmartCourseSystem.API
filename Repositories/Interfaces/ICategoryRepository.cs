using SmartCourseSystem.API.Models;

namespace SmartCourseSystem.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>>
        GetAllAsync();

        Task<Category?>
            GetByIdAsync(int id);

        Task AddAsync(Category category);

        void Update(Category category);

        void Delete(Category category);

        Task SaveChangesAsync();
    }
}
