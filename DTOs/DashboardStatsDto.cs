namespace SmartCourseSystem.API.DTOs
{
    public class DashboardStatsDto
    {
        public int TotalStudents { get; set; }

        public int TotalCourses { get; set; }

        public int TotalCategories { get; set; }

        public int TotalEnrollments { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
