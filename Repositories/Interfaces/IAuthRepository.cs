using SmartCourseSystem.API.Models;

namespace SmartCourseSystem.API.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task AddUserAsync(User user);

        Task SaveChangesAsync();
    }
}
