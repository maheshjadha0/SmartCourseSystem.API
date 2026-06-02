using CloudinaryDotNet;

namespace SmartCourseSystem.API.Models
{
    public class User
    {
        public int ID { get; set; }

        public string FullName { get; set; }
       = string.Empty;

        public string Email { get; set; }
            = string.Empty;

        public string PasswordHash { get; set; }
            = string.Empty;

        public string? ProfileImageUrl { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Role Role { get; set; }

        public ICollection<Course> Courses { get; set; }
            = new List<Course>();

        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();
    }
}
