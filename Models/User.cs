using Microsoft.AspNetCore.Identity;

namespace ExaminationSystem.Models
{
    public class User: IdentityUser<int>
    {
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
        public DateTime? LastModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int UpdatedBy { get; set; }


    }
}
