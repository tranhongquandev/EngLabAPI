using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace EngLabAPI.Helper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EngLabAPI.Model.Entities.Student, EngLabAPI.DTOs.Student.GetStudentDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Student, EngLabAPI.DTOs.Student.CreateStudentDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Student, EngLabAPI.DTOs.Student.UpdateStudentDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Student, EngLabAPI.DTOs.Student.DeleteStudentDTO>().ReverseMap();

            CreateMap<EngLabAPI.Model.Entities.Teacher, EngLabAPI.DTOs.Teacher.GetTeacherDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Teacher, EngLabAPI.DTOs.Teacher.UpdateTeacherDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Teacher, EngLabAPI.DTOs.Teacher.CreateTeacherDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Teacher, EngLabAPI.DTOs.Teacher.DeleteTeacherDTO>().ReverseMap();


            CreateMap<EngLabAPI.Model.Entities.Course, EngLabAPI.DTOs.Course.GetCourseDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Course, EngLabAPI.DTOs.Course.UpdateCourseDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Course, EngLabAPI.DTOs.Course.CreateCourseDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Course, EngLabAPI.DTOs.Course.DeleteCourseDTO>().ReverseMap();


            CreateMap<EngLabAPI.Model.Entities.Class, EngLabAPI.DTOs.Class.GetClassDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Class, EngLabAPI.DTOs.Class.UpdateClassDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Class, EngLabAPI.DTOs.Class.CreateClassDTO>().ReverseMap();
            CreateMap<EngLabAPI.Model.Entities.Class, EngLabAPI.DTOs.Class.DeleteClassDTO>().ReverseMap();


        }
    }
}