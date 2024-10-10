using EngLabAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLabAPI.Model.Configurations
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LevelCode).HasMaxLength(20).IsRequired();
            builder.Property(x => x.LevelName).HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.Language).WithMany(x => x.Level).HasForeignKey(x => x.LanguageId);

            #region Seed Data
            builder.HasData(
                    // English Levels
                    new Level { Id = 1, LanguageId = 1, LevelCode = "A1", LevelName = "Beginner" },
                    new Level { Id = 2, LanguageId = 1, LevelCode = "A2", LevelName = "Elementary" },
                    new Level { Id = 3, LanguageId = 1, LevelCode = "B1", LevelName = "Intermediate" },
                    new Level { Id = 4, LanguageId = 1, LevelCode = "B2", LevelName = "Upper Intermediate" },
                    new Level { Id = 5, LanguageId = 1, LevelCode = "C1", LevelName = "Advanced" },
                    new Level { Id = 6, LanguageId = 1, LevelCode = "C2", LevelName = "Proficient" },

                    // French Levels
                    new Level { Id = 7, LanguageId = 2, LevelCode = "A1", LevelName = "Débutant" },
                    new Level { Id = 8, LanguageId = 2, LevelCode = "A2", LevelName = "Élémentaire" },
                    new Level { Id = 9, LanguageId = 2, LevelCode = "B1", LevelName = "Intermédiaire" },
                    new Level { Id = 10, LanguageId = 2, LevelCode = "B2", LevelName = "Supérieur" },
                    new Level { Id = 11, LanguageId = 2, LevelCode = "C1", LevelName = "Avancé" },
                    new Level { Id = 12, LanguageId = 2, LevelCode = "C2", LevelName = "Maîtrise" },

                    // Spanish Levels
                    new Level { Id = 13, LanguageId = 3, LevelCode = "A1", LevelName = "Principiante" },
                    new Level { Id = 14, LanguageId = 3, LevelCode = "A2", LevelName = "Elemental" },
                    new Level { Id = 15, LanguageId = 3, LevelCode = "B1", LevelName = "Intermedio" },
                    new Level { Id = 16, LanguageId = 3, LevelCode = "B2", LevelName = "Avanzado" },
                    new Level { Id = 17, LanguageId = 3, LevelCode = "C1", LevelName = "Superior" },
                    new Level { Id = 18, LanguageId = 3, LevelCode = "C2", LevelName = "Maestría" },

                    // Chinese Levels
                    new Level { Id = 19, LanguageId = 4, LevelCode = "HSK 1", LevelName = "Beginner" },
                    new Level { Id = 20, LanguageId = 4, LevelCode = "HSK 2", LevelName = "Elementary" },
                    new Level { Id = 21, LanguageId = 4, LevelCode = "HSK 3", LevelName = "Intermediate" },
                    new Level { Id = 22, LanguageId = 4, LevelCode = "HSK 4", LevelName = "Upper Intermediate" },
                    new Level { Id = 23, LanguageId = 4, LevelCode = "HSK 5", LevelName = "Advanced" },
                    new Level { Id = 24, LanguageId = 4, LevelCode = "HSK 6", LevelName = "Proficient" },

                    // Japanese Levels
                    new Level { Id = 25, LanguageId = 5, LevelCode = "N5", LevelName = "Beginner" },
                    new Level { Id = 26, LanguageId = 5, LevelCode = "N4", LevelName = "Elementary" },
                    new Level { Id = 27, LanguageId = 5, LevelCode = "N3", LevelName = "Intermediate" },
                    new Level { Id = 28, LanguageId = 5, LevelCode = "N2", LevelName = "Upper Intermediate" },
                    new Level { Id = 29, LanguageId = 5, LevelCode = "N1", LevelName = "Advanced" }
                );

            #endregion
        }
    }
}
