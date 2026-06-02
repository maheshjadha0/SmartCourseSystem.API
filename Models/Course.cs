namespace SmartCourseSystem.API.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string Title { get; set; }
            = string.Empty;

        public string Description { get; set; }
            = string.Empty;

        public decimal Price { get; set; }

        public string? ThumbnailUrl { get; set; }

        public int CategoryId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation Properties

        public Category Category { get; set; }

        public User User { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
            = new List<Lesson>();

        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();
    }
}
