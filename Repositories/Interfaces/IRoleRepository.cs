using SmartCourseSystem.API.Models;

namespace SmartCourseSystem.API.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();

        Task<Role?> GetByIdAsync(int id);

        Task AddAsync(Role role);

        void Update(Role role);

        void Delete(Role role);

        Task SaveChangesAsync();
    }
}
