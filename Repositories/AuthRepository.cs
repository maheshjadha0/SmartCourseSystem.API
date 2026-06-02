using Microsoft.EntityFrameworkCore;
using SmartCourseSystem.API.Data;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;

namespace SmartCourseSystem.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(
            string email)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x =>
                    x.Email == email);
        }

       
        public async Task AddUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while adding user: {ex.Message}", ex);
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
