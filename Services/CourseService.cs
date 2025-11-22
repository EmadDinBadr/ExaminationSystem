using ExaminationSystem.DTOs;
using ExaminationSystem.DTOs.Course;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ExaminationSystem.Services
{
    public class CourseService
    {
        GeneralRepository<Course> _generalRepository;
        GeneralRepository<Exam> _ExamRepository;
        IMapper _mapper;
        public CourseService(IMapper mapper)
        {
            _ExamRepository = new GeneralRepository<Exam>();
            _generalRepository = new GeneralRepository<Course>();
            _mapper = mapper;
        }

        public IEnumerable<GetAllCoursesDTO> GetAll()
        {
            //var query =  _generalRepository.GetAll().Select(c => new GetAllCoursesDTO()
            //{
            //    Name = c.Name, 
            //    ID = c.ID,
            //    Description = c.Description,
            //    Instructor = new DTOs.Instructor.GetInstructorInfoDTO()
            //    {
            //        ID = c.Instructor.ID,
            //        Name = c.Instructor.FullName,  
            //    }
            //}).ToList(); 
            var query = _generalRepository.GetAll().Include(c => c.Instructor).Select(c => c.ProjectCourseTo());//.ToList();
                                                                                                                //  var query = _generalRepository.GetAll().ProjectTo<GetAllCoursesDTO>(_mapper.ConfigurationProvider); //.Select(c => c.ProjectCourseTo());//.ToList();
            return query;
        }
        public async Task<Course> GetByID(int id)
        {
            var res = await _generalRepository.GetByID(id);
            return res;
        }
        public async Task<Course> GetByIDWithTracking(int id)
        {
            var res = await _generalRepository.GetByIDWithTracking(id);
            return res;
        }
        public async Task Add(Course course)
        {
            _generalRepository.Add(course);
        }
        public void Update(UpdateCourseRequestDTO course)
        {
            var crs = new Course()
            {
                Name = course.Name,
                Hours = course.Hours,
            };
            _generalRepository.Update(crs);
        }
    }

}
