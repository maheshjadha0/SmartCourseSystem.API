using SmartCourseSystem.API.DTOs;
using SmartCourseSystem.API.Models;

namespace SmartCourseSystem.API.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRolesAsync();

        Task<Role?> GetRoleByIdAsync(int id);

        Task<Role> CreateRoleAsync(CreateRoleDto dto);

        Task<bool> UpdateRoleAsync(int id, UpdateRoleDto dto);

        Task<bool> DeleteRoleAsync(int id);
    }
}
