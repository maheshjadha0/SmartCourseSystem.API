namespace SmartCourseSystem.API.DTOs.Course
{
    public class CourseResponseDto
    {
        public int ID { get; set; }

        public string Title { get; set; }
            = string.Empty;

        public string Description { get; set; }
            = string.Empty;

        public decimal Price { get; set; }

        public string? ThumbnailUrl { get; set; }

        public string CategoryName { get; set; }
            = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}

