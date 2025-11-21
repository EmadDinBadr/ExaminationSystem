namespace ExaminationSystem.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int UpdatedBy { get; set; }
    }
}
