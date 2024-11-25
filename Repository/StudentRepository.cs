using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Student;
using EngLabAPI.Model.Context;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepostory
    {
        public StudentRepository(EngLabContext context) : base(context)
        {
        }
        
       
    }
}