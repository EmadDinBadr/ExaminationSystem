using ExaminationSystem.Data;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExaminationSystem.Repositories
{
    public class ExamRepository : GeneralRepository<Exam>
    {
        EXContext _context;
        CourseRepository _courseRepository; 
        public ExamRepository()
        {
            _context = new EXContext();
            _courseRepository = new CourseRepository();
        }

 
        public async void Update(Exam Exam)
        {
            _context.Update(Exam);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var res = await GetByIDWithTracking(id);
            res.IsDeleted = true;   

            await _context.SaveChangesAsync();
        }
        public bool IsExamExist(int id)
        {
            return true;
        }

    }
}
