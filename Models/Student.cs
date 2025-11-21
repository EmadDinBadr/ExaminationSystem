namespace ExaminationSystem.Models
{
    public class Student:User
    {
        public ICollection<StudentCourse> Enrollments { get; set; } = new List<StudentCourse>();
        public ICollection<StudentExam> AssignedExams { get; set; } = new List<StudentExam>();
        public ICollection<ExamSubmission> Submissions { get; set; } = new List<ExamSubmission>();
    }
}
