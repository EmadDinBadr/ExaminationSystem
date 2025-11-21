namespace ExaminationSystem.Models
{
    public class Instructor: User
    {
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}
