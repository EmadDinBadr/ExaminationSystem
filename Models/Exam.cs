using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.Models
{
    public class Exam : BaseEntity
    {
        public string Title { get; set; }
        public ExamType ExamType { get; set; }
        public int NumberOfQuestions { get; set; }
        public ExamCreationMode CreationMode { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public decimal FullMark { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime Deadline { get; set; }

        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
        public ICollection<StudentExam> AssignedStudents { get; set; } = new List<StudentExam>();
        public ICollection<ExamSubmission> Submissions { get; set; } = new List<ExamSubmission>();
    }
}
