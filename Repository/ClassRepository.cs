using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.Model.Context;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(EngLabContext context) : base(context)
        {
        }
    }
}