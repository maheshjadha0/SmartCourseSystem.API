using Microsoft.EntityFrameworkCore;
using SmartCourseSystem.API.Data;
using SmartCourseSystem.API.DTOs;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserResponseDto>>
            GetStudentsAsync()
        {
            return await _context.Users

                .Where(x => x.RoleId == 2)

                .Select(x => new UserResponseDto
                {
                    Id = x.ID,
                    FullName = x.FullName,
                    Email = x.Email
                })

                .ToListAsync();
        }
    }
}
