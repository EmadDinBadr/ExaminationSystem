namespace ExaminationSystem.Models
{
    public class Choice:BaseEntity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public string choiceBody { get; set; }
        public bool IsCorrect { get; set; }
    }
}
