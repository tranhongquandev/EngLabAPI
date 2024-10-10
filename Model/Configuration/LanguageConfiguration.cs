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
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LanguageName).IsRequired().HasMaxLength(50);

            #region Seed Data
            builder.HasData(
                    new Language { Id = 1, LanguageName = "Tiếng Anh" },
                    new Language { Id = 2, LanguageName = "Tiếng Pháp" },
                    new Language { Id = 3, LanguageName = "Tiếng Tây Ban Nha" },
                    new Language { Id = 4, LanguageName = "Tiếng Trung" },
                    new Language { Id = 5, LanguageName = "Tiếng Nhật" }
                );
            #endregion

        }
    }
}
