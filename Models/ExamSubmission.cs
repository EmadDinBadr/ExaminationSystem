namespace ExaminationSystem.Models
{
    public class ExamSubmission: BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public decimal Score { get; set; }

        public ICollection<SubmissionAnswer> Answers { get; set; } = new List<SubmissionAnswer>();
    }
}
