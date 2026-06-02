using SmartCourseSystem.API.DTOs;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Role> CreateRoleAsync(CreateRoleDto dto)
        {
            var role = new Role
            {
                Name = dto.Name
            };

            await _repository.AddAsync(role);
            await _repository.SaveChangesAsync();

            return role;
        }

        public async Task<bool> UpdateRoleAsync(int id, UpdateRoleDto dto)
        {
            var role = await _repository.GetByIdAsync(id);

            if (role == null)
                return false;

            role.Name = dto.Name;

            _repository.Update(role);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _repository.GetByIdAsync(id);

            if (role == null)
                return false;

            _repository.Delete(role);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
