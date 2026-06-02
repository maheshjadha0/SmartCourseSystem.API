namespace SmartCourseSystem.API.Models
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
