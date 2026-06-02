using Microsoft.EntityFrameworkCore;
using SmartCourseSystem.API.Data;
using SmartCourseSystem.API.DTOs;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardStatsDto>
            GetStatsAsync()
        {
            var students =
                await _context.Users
                .CountAsync(x => x.RoleId == 2);

            var courses =
                await _context.Courses.CountAsync();

            var categories =
                await _context.Categories.CountAsync();

            var enrollments =
                await _context.Enrollments.CountAsync();

            var revenue =
                await _context.Enrollments
                .Include(x => x.Course)
                .SumAsync(x => x.Course.Price);

            return new DashboardStatsDto
            {
                TotalStudents = students,
                TotalCourses = courses,
                TotalCategories = categories,
                TotalEnrollments = enrollments,
                TotalRevenue = revenue
            };
        }
    }
}
