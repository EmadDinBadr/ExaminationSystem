using ExaminationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace ExaminationSystem.Data
{
    public class EXContext:IdentityDbContext<User, IdentityRole<int>, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = .; initial catalog = EaminationSys ; integrated security = true; trust server certificate = true ")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging(true);
        }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get;set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<ExamSubmission> ExamSubmissions { get; set; }
        public DbSet<SubmissionAnswer> SubmissionAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Instructor>().ToTable("Instructors");
            builder.Entity<Student>().ToTable("Students");

            builder.Entity<Instructor>()
                .HasMany(i => i.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Instructor>()
                .HasMany(i => i.Questions)
                .WithOne(q => q.Instructor)
                .HasForeignKey(q => q.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Instructor>()
                .HasMany(i => i.Exams)
                .WithOne(e => e.Instructor)
                .HasForeignKey(e => e.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentCourse>()
                .HasKey(sc => sc.Id);

            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<StudentExam>()
                .HasKey(se => new { se.StudentId, se.ExamId });

            builder.Entity<StudentExam>()
                .HasOne(se => se.Student)
                .WithMany(s => s.AssignedExams)
                .HasForeignKey(se => se.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<StudentExam>()
                .HasOne(se => se.Exam)
                .WithMany(e => e.AssignedStudents)
                .HasForeignKey(se => se.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ExamQuestion>()
                .HasKey(eq => new { eq.ExamId, eq.QuestionId });

            builder.Entity<ExamQuestion>()
                .HasOne(eq => eq.Exam)
                .WithMany(e => e.ExamQuestions)
                .HasForeignKey(eq => eq.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ExamQuestion>()
                .HasOne(eq => eq.Question)
                .WithMany(q => q.ExamQuestions)
                .HasForeignKey(eq => eq.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Choice>()
                .HasOne(c => c.Question)
                .WithMany(q => q.Choices)
                .HasForeignKey(c => c.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ExamSubmission>()
                .HasOne(es => es.Student)
                .WithMany(s => s.Submissions)
                .HasForeignKey(es => es.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ExamSubmission>()
                .HasOne(es => es.Exam)
                .WithMany(e => e.Submissions)
                .HasForeignKey(es => es.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SubmissionAnswer>()
                .HasOne(sa => sa.ExamSubmission)
                .WithMany(es => es.Answers)
                .HasForeignKey(sa => sa.ExamSubmissionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SubmissionAnswer>()
                .HasOne(sa => sa.Question)
                .WithMany()
                .HasForeignKey(sa => sa.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SubmissionAnswer>()
                .HasOne(sa => sa.SelectedChoice)
                .WithMany()
                .HasForeignKey(sa => sa.SelectedChoiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
