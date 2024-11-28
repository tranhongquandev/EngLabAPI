using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLabAPI.Model.Entities
{
    public class Level
    {
        public int Id { get; set; }

        public string? LevelCode { get; set; }

        public string? LevelName { get; set; }

        public int LanguageId { get; set; }

    }
}
