using ExaminationSystem.Data;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExaminationSystem.Repositories
{
    public class CourseRepository : GeneralRepository<Course>
    {
        EXContext _context;
        ExamRepository _examRepository;  
        public CourseRepository()
        {
            _context = new EXContext();
            _examRepository = new ExamRepository(); 
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var res = await _context.Courses.ToListAsync();
            return res;
        }
        public async Task<Course> GetByID(int id)
        {
            var res = await _context.Courses.Where(c => c.Id == id).FirstOrDefaultAsync();
            return res;
        }
        public async Task<Course> GetByIDWithTracking(int id)
        {
            var res = await _context.Courses.AsTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return res;
        }
        public async Task Add(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }
        public async void Update(Course course)
        {
            _context.Update(course);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var res = await GetByIDWithTracking(id);
            res.IsDeleted = true;   

            await _context.SaveChangesAsync();
        }
        public void AssignExamToCourse(Exam exam)
        {
           bool res = _examRepository.IsExamExist(exam.Id);
            if(res)
            {

            }
        }
    }
}
