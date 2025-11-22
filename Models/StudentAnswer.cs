namespace ExaminationSystem.Models
{
    public class StudentAnswer : BaseModel
    {
        public int StudentExamId { get; set; }
        public StudentExam StudentExam { get; set; } = null!;

        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;

        public int SelectedChoiceId { get; set; }
        public Choice SelectedChoice { get; set; } = null!;
    }
} 