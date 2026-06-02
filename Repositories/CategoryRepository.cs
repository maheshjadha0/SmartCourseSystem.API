using Microsoft.EntityFrameworkCore;
using SmartCourseSystem.API.Data;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;

namespace SmartCourseSystem.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>>
            GetAllAsync()
        {
            return await _context.Categories
                .ToListAsync();
        }

        public async Task<Category?>
            GetByIdAsync(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(x =>
                    x.ID == id);
        }

        public async Task AddAsync(
            Category category)
        {
            await _context.Categories
                .AddAsync(category);
        }

        public void Update(
            Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(
            Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
