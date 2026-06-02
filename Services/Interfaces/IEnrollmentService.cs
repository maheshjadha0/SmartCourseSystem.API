using SmartCourseSystem.API.DTOs.Enrollment;

namespace SmartCourseSystem.API.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentResponseDto>>
           GetAllAsync();

        Task<EnrollmentResponseDto>
            PurchaseCourseAsync(
                int userId,
                CreateEnrollmentDto dto);

        Task<bool>
            DeleteAsync(int id);
    }
}
