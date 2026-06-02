using SmartCourseSystem.API.DTOs.Enrollment;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Services
{
    public class EnrollmentService
   : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentService(
            IEnrollmentRepository repository,
            ICourseRepository courseRepository)
        {
            _repository = repository;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<EnrollmentResponseDto>>
            GetAllAsync()
        {
            var enrollments =
                await _repository.GetAllAsync();

            return enrollments.Select(x =>
                new EnrollmentResponseDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    StudentName = x.User.FullName,
                    CourseId = x.CourseId,
                    CourseName = x.Course.Title,
                    PurchaseDate = x.PurchaseDate
                });
        }

        public async Task<EnrollmentResponseDto>
            PurchaseCourseAsync(
                int userId,
                CreateEnrollmentDto dto)
        {
            var course =
                await _courseRepository
                    .GetByIdAsync(dto.CourseId);

            if (course == null)
                throw new Exception(
                    "Course Not Found");

            bool alreadyPurchased =
                await _repository
                    .IsAlreadyPurchasedAsync(
                        userId,
                        dto.CourseId);

            if (alreadyPurchased)
                throw new Exception(
                    "Course Already Purchased");

            var enrollment =
                new Enrollment
                {
                    UserId = userId,
                    CourseId = dto.CourseId,
                    PurchaseDate = DateTime.UtcNow
                };

            await _repository
                .AddAsync(enrollment);

            await _repository
                .SaveChangesAsync();

            return new EnrollmentResponseDto
            {
                Id = enrollment.Id,
                UserId = userId,
                CourseId = dto.CourseId,
                CourseName = course.Title,
                PurchaseDate = enrollment.PurchaseDate
            };
        }

        public async Task<bool>
            DeleteAsync(int id)
        {
            var enrollment =
                await _repository.GetByIdAsync(id);

            if (enrollment == null)
                return false;

            _repository.Delete(enrollment);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
