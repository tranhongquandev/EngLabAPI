using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.Model.Context;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(EngLabContext context) : base(context)
        {
        }
    }
}