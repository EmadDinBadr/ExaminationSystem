using ExaminationSystem.Data;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExaminationSystem.Repositories
{
    public class CourseRepository : GeneralRepository<Course>
    {
        ExamRepository _examRepository;  
        public CourseRepository()
        {
            //_context = new EXContext();
            _examRepository = new ExamRepository(); 
        }

        public void AssignExamToCourse(Exam exam)
        {
           bool res = _examRepository.IsExamExist(exam.ID);
            if(res)
            {

            }
        }
    }
}
