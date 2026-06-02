namespace SmartCourseSystem.API.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Title { get; set; }
            = string.Empty;

        public string VideoUrl { get; set; }
            = string.Empty;

        // Navigation Property
        public Course Course { get; set; }
    }
}
