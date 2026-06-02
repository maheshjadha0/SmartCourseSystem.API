namespace SmartCourseSystem.API.DTOs.Lesson
{
    public class CreateLessonDto
    {
        public int CourseId { get; set; }

        public string Title { get; set; }
            = string.Empty;

        public string VideoUrl { get; set; }
            = string.Empty;
    }
}
