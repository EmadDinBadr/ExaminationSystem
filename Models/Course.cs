namespace ExaminationSystem.Models
{
    public class Course:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}
