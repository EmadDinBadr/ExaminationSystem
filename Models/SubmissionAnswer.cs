namespace ExaminationSystem.Models
{
    public class SubmissionAnswer:BaseEntity
    {
        public int ExamSubmissionId { get; set; }
        public ExamSubmission ExamSubmission { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int? SelectedChoiceId { get; set; }
        public Choice SelectedChoice { get; set; }
    }
}
