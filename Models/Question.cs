using System.ComponentModel.DataAnnotations;
using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.Models
{
    public class Question : BaseModel
    {

        [Required]
        public string Text { get; set; } = null!;

        public QuestionLevel Level { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;

        public ICollection<Choice> Choices { get; set; } = new List<Choice>();
        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
    }
} 