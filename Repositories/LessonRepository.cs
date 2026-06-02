using Microsoft.EntityFrameworkCore;
using SmartCourseSystem.API.Data;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;

namespace SmartCourseSystem.API.Repositories
{
    public class LessonRepository
   : ILessonRepository
    {
        private readonly ApplicationDbContext _context;

        public LessonRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>>
            GetAllAsync()
        {
            return await _context.Lessons
                .Include(x => x.Course)
                .ToListAsync();
        }

        public async Task<Lesson?>
            GetByIdAsync(int id)
        {
            return await _context.Lessons
                .Include(x => x.Course)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(
            Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
        }

        public void Update(
            Lesson lesson)
        {
            _context.Lessons.Update(lesson);
        }

        public void Delete(
            Lesson lesson)
        {
            _context.Lessons.Remove(lesson);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
