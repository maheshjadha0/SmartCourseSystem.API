using SmartCourseSystem.API.DTOs.Lesson;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ICourseRepository _courseRepository;

        public LessonService(
            ILessonRepository lessonRepository,
            ICourseRepository courseRepository)
        {
            _lessonRepository = lessonRepository;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<LessonResponseDto>>
            GetAllAsync()
        {
            var lessons =
                await _lessonRepository.GetAllAsync();

            return lessons.Select(x =>
                new LessonResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    VideoUrl = x.VideoUrl,
                    CourseId = x.CourseId,
                    CourseName = x.Course.Title
                });
        }

        public async Task<LessonResponseDto?>
            GetByIdAsync(int id)
        {
            var lesson =
                await _lessonRepository.GetByIdAsync(id);

            if (lesson == null)
                return null;

            return new LessonResponseDto
            {
                Id = lesson.Id,
                Title = lesson.Title,
                VideoUrl = lesson.VideoUrl,
                CourseId = lesson.CourseId,
                CourseName = lesson.Course.Title
            };
        }

        public async Task<LessonResponseDto>
            CreateAsync(CreateLessonDto dto)
        {
            var course =
                await _courseRepository
                    .GetByIdAsync(dto.CourseId);

            if (course == null)
                throw new Exception("Course Not Found");

            var lesson = new Lesson
            {
                Title = dto.Title,
                VideoUrl = dto.VideoUrl,
                CourseId = dto.CourseId
            };

            await _lessonRepository.AddAsync(lesson);

            await _lessonRepository.SaveChangesAsync();

            return new LessonResponseDto
            {
                Id = lesson.Id,
                Title = lesson.Title,
                VideoUrl = lesson.VideoUrl,
                CourseId = lesson.CourseId,
                CourseName = course.Title
            };
        }

        public async Task<bool>
            UpdateAsync(
                int id,
                UpdateLessonDto dto)
        {
            var lesson =
                await _lessonRepository.GetByIdAsync(id);

            if (lesson == null)
                return false;

            lesson.Title = dto.Title;
            lesson.VideoUrl = dto.VideoUrl;

            _lessonRepository.Update(lesson);

            await _lessonRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool>
            DeleteAsync(int id)
        {
            var lesson =
                await _lessonRepository.GetByIdAsync(id);

            if (lesson == null)
                return false;

            _lessonRepository.Delete(lesson);

            await _lessonRepository.SaveChangesAsync();

            return true;
        }
    }
}
