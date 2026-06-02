using SmartCourseSystem.API.DTOs;

namespace SmartCourseSystem.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDto>>
        GetStudentsAsync();
    }
}
