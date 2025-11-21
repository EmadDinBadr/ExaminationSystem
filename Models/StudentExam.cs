namespace ExaminationSystem.Models
{
    public class StudentExam
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        //
    }
}
