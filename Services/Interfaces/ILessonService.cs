using SmartCourseSystem.API.DTOs.Lesson;

namespace SmartCourseSystem.API.Services.Interfaces
{
    public interface ILessonService
    {
        Task<IEnumerable<LessonResponseDto>>
            GetAllAsync();

        Task<LessonResponseDto?>
            GetByIdAsync(int id);

        Task<LessonResponseDto>
            CreateAsync(CreateLessonDto dto);

        Task<bool>
            UpdateAsync(
                int id,
                UpdateLessonDto dto);

        Task<bool>
            DeleteAsync(int id);
    }
}
