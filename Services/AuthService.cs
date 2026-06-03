using SmartCourseSystem.API.DTOs;
using SmartCourseSystem.API.Helpers;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        private readonly JwtHelper _jwtHelper;

        public AuthService(
            IAuthRepository repository,
            JwtHelper jwtHelper)
        {
            _repository = repository;
            _jwtHelper = jwtHelper;
        }

        public async Task<string> RegisterAsync(
            RegisterDto dto)
        {
            var existingUser =
                await _repository
                    .GetUserByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return "User already exists";
            }

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,

                PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword(
                        dto.Password),

                RoleId = 1,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddUserAsync(user);

            await _repository.SaveChangesAsync();

            return "Registration successful";
        }

        public async Task<AuthResponseDto?> LoginAsync(
            LoginDto dto)
        {
            var user =
                await _repository
                    .GetUserByEmailAsync(dto.Email);

            if (user == null)
            {
                return null;
            }

            bool isPasswordValid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.PasswordHash);

            if (!isPasswordValid)
            {
                return null;
            }

            var token =
                _jwtHelper.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                Role = user.Role.Name
            };
        }
    }
}
