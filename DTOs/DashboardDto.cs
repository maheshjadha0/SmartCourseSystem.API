namespace SmartCourseSystem.API.DTOs
{
    public class DashboardDto
    {
        public int TotalUsers { get; set; }

        public int TotalCourses { get; set; }

        public int TotalEnrollments { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
