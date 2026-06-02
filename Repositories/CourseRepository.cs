using Microsoft.EntityFrameworkCore;
using SmartCourseSystem.API.Data;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;

namespace SmartCourseSystem.API.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>>
            GetAllAsync()
        {
            return await _context.Courses
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Course?>
            GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task AddAsync(
            Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        public void Update(
            Course course)
        {
            _context.Courses.Update(course);
        }

        public void Delete(
            Course course)
        {
            _context.Courses.Remove(course);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
