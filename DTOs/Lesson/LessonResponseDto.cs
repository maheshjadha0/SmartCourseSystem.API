namespace SmartCourseSystem.API.DTOs.Lesson
{
    public class LessonResponseDto
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }
            = string.Empty;

        public string Title { get; set; }
            = string.Empty;

        public string VideoUrl { get; set; }
            = string.Empty;
    }
}
