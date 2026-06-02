using CloudinaryDotNet;

namespace SmartCourseSystem.API.Models
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }
            = string.Empty;

        // Navigation Property
        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}
