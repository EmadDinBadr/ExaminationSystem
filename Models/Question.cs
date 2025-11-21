using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.Models
{
    public class Question : BaseEntity
    {
        public QuestionLevel Level { get; set; }
        public QuestionType questionType { get; set; }
        public string Body { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public decimal QuestionDegree { get; set; }
        public ICollection<Choice> Choices { get; set; } = new List<Choice>();
        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
    }
}
