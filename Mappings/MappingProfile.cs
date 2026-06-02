using AutoMapper;
using SmartCourseSystem.API.DTOs.Course;
using SmartCourseSystem.API.Models;

namespace SmartCourseSystem.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseResponseDto>();

            CreateMap<CreateCourseDto, Course>();
        }
    }
}
