using SmartCourseSystem.API.DTOs;

namespace SmartCourseSystem.API.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardStatsDto>
          GetStatsAsync();
    }
}
