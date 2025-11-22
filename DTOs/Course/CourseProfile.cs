using AutoMapper;
using ExaminationSystem.DTOs.Instructor;
using ExaminationSystem.ViewModels.Course;
using ExaminationSystem.ViewModels.Instructor;

namespace ExaminationSystem.DTOs.Course
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<ExaminationSystem.Models.Course, GetAllCoursesDTO>();
            CreateMap<GetAllCoursesViewModel, GetAllCoursesDTO>().ReverseMap();
            CreateMap<GetInstructorInfoDTO, GetInstuctorInfoViewModel>().ReverseMap();
            //.ForPath(dst => dst.Instructor.Name, opt => opt.MapFrom(src => src.Instructor.FullName));
            CreateMap<ExaminationSystem.Models.Instructor, GetInstructorInfoDTO>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(scr => scr.FullName))
                .ReverseMap();

        }
    }
}
