using Microsoft.EntityFrameworkCore;
using SmartCourseSystem.API.Data;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;

namespace SmartCourseSystem.API.Repositories
{
    public class EnrollmentRepository
   : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrollment>>
            GetAllAsync()
        {
            return await _context.Enrollments
                .Include(x => x.User)
                .Include(x => x.Course)
                .ToListAsync();
        }

        public async Task<Enrollment?>
            GetByIdAsync(int id)
        {
            return await _context.Enrollments
                .Include(x => x.User)
                .Include(x => x.Course)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool>
            IsAlreadyPurchasedAsync(
                int userId,
                int courseId)
        {
            return await _context.Enrollments
                .AnyAsync(x =>
                    x.UserId == userId &&
                    x.CourseId == courseId);
        }

        public async Task AddAsync(
            Enrollment enrollment)
        {
            await _context.Enrollments
                .AddAsync(enrollment);
        }

        public void Delete(
            Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
