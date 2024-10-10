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
            CreateMap<EngLabAPI.Model.Entities.Student, EngLabAPI.DTOs.StudentDTO>().ReverseMap();
            // CreateMap<EngLabAPI.Model.Entities.Student, EngLabAPI.Model.DTO.StudentCreateDTO>().ReverseMap();
            // CreateMap<EngLabAPI.Model.Entities.Student, EngLabAPI.Model.DTO.StudentUpdateDTO>().ReverseMap();
            // CreateMap<EngLabAPI.Model.Entities.Student, EngLabAPI.Model.DTO.StudentDeleteDTO>().ReverseMap();

            CreateMap<EngLabAPI.Model.Entities.Teacher, EngLabAPI.DTOs.TeacherDTO>().ReverseMap();

        }
    }
}