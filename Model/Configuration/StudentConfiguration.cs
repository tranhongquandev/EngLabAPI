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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StudentCode).HasDefaultValue(GenerateRandomString());
            builder.Property(x => x.FullName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Gender).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.DateOfBirth);
            builder.Property(x => x.EnrollmentDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.Status).HasMaxLength(50).HasDefaultValue("Chưa có lớp");

            #region Seed Data
            builder.HasData(

                new Student { Id = 1, StudentCode = "HV001", FullName = "Nguyễn Văn A", Gender = "Nam", Email = "nguyenvana@example.com", PhoneNumber = "0987654321", DateOfBirth = new DateTime(2000, 5, 15), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 2, StudentCode = "HV002", FullName = "Trần Thị B", Gender = "Nữ", Email = "tranthib@example.com", PhoneNumber = "0912345678", DateOfBirth = new DateTime(1999, 3, 22), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 3, StudentCode = "HV003", FullName = "Lê Văn C", Gender = "Nam", Email = "levanc@example.com", PhoneNumber = "0923456789", DateOfBirth = new DateTime(2001, 12, 1), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 4, StudentCode = "HV004", FullName = "Phạm Thị D", Gender = "Nữ", Email = "phamthid@example.com", PhoneNumber = "0981234567", DateOfBirth = new DateTime(1998, 7, 20), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 5, StudentCode = "HV005", FullName = "Đỗ Văn E", Gender = "Nam", Email = "dovane@example.com", PhoneNumber = "0976543210", DateOfBirth = new DateTime(1997, 4, 10), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 6, StudentCode = "HV006", FullName = "Hoàng Minh F", Gender = "Nam", Email = "hoangminhf@example.com", PhoneNumber = "0912345678", DateOfBirth = new DateTime(1999, 2, 5), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 7, StudentCode = "HV007", FullName = "Nguyễn Văn G", Gender = "Nam", Email = "nguyenvang@example.com", PhoneNumber = "0922345678", DateOfBirth = new DateTime(1998, 8, 18), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 8, StudentCode = "HV008", FullName = "Vũ Thị H", Gender = "Nữ", Email = "vuthih@example.com", PhoneNumber = "0934567890", DateOfBirth = new DateTime(2000, 1, 11), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 9, StudentCode = "HV009", FullName = "Bùi Văn I", Gender = "Nam", Email = "buivani@example.com", PhoneNumber = "0909876543", DateOfBirth = new DateTime(1996, 11, 30), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 10, StudentCode = "HV010", FullName = "Phan Thị J", Gender = "Nữ", Email = "phanthij@example.com", PhoneNumber = "0987654321", DateOfBirth = new DateTime(2002, 9, 10), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },

                // Mock data for additional 40 students
                new Student { Id = 11, StudentCode = "HV011", FullName = "Trương Văn K", Gender = "Nam", Email = "truongvank@example.com", PhoneNumber = "0981112233", DateOfBirth = new DateTime(1999, 2, 21), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 12, StudentCode = "HV012", FullName = "Nguyễn Thị L", Gender = "Nữ", Email = "nguyenthil@example.com", PhoneNumber = "0992223344", DateOfBirth = new DateTime(1997, 4, 1), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 13, StudentCode = "HV013", FullName = "Lý Văn M", Gender = "Nam", Email = "lyvanm@example.com", PhoneNumber = "0912345678", DateOfBirth = new DateTime(1995, 7, 15), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 14, StudentCode = "HV014", FullName = "Ngô Thị N", Gender = "Nữ", Email = "ngothin@example.com", PhoneNumber = "0922345678", DateOfBirth = new DateTime(1998, 3, 23), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 15, StudentCode = "HV015", FullName = "Trần Văn O", Gender = "Nam", Email = "tranvano@example.com", PhoneNumber = "0908765432", DateOfBirth = new DateTime(1994, 9, 5), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 16, StudentCode = "HV016", FullName = "Phạm Minh P", Gender = "Nam", Email = "phamminhp@example.com", PhoneNumber = "0912345678", DateOfBirth = new DateTime(2000, 12, 3), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 17, StudentCode = "HV017", FullName = "Trịnh Thị Q", Gender = "Nữ", Email = "trinhthiq@example.com", PhoneNumber = "0934456677", DateOfBirth = new DateTime(1996, 5, 17), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 18, StudentCode = "HV018", FullName = "Đặng Văn R", Gender = "Nam", Email = "dangvanr@example.com", PhoneNumber = "0909871234", DateOfBirth = new DateTime(1995, 8, 9), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 19, StudentCode = "HV019", FullName = "Lương Thị S", Gender = "Nữ", Email = "luongthis@example.com", PhoneNumber = "0977889900", DateOfBirth = new DateTime(1999, 10, 10), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 20, StudentCode = "HV020", FullName = "Phan Văn T", Gender = "Nam", Email = "phanvant@example.com", PhoneNumber = "0923345678", DateOfBirth = new DateTime(1997, 6, 28), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },

                // Continue adding more students up to 50...
                new Student { Id = 21, StudentCode = "HV021", FullName = "Nguyễn Văn U", Gender = "Nam", Email = "nguyenvanu@example.com", PhoneNumber = "0911234567", DateOfBirth = new DateTime(1998, 11, 12), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 22, StudentCode = "HV022", FullName = "Vũ Thị V", Gender = "Nữ", Email = "vuthiv@example.com", PhoneNumber = "0942345678", DateOfBirth = new DateTime(1997, 2, 10), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 23, StudentCode = "HV023", FullName = "Trương Thị W", Gender = "Nữ", Email = "truongthiww@example.com", PhoneNumber = "0976456789", DateOfBirth = new DateTime(2001, 9, 14), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 24, StudentCode = "HV024", FullName = "Lê Văn X", Gender = "Nam", Email = "levanx@example.com", PhoneNumber = "0923456789", DateOfBirth = new DateTime(1999, 7, 6), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 25, StudentCode = "HV025", FullName = "Nguyễn Thị Y", Gender = "Nữ", Email = "nguyenthiy@example.com", PhoneNumber = "0908765432", DateOfBirth = new DateTime(1998, 12, 25), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 26, StudentCode = "HV026", FullName = "Bùi Văn Z", Gender = "Nam", Email = "buivanz@example.com", PhoneNumber = "0912345678", DateOfBirth = new DateTime(1995, 4, 30), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 27, StudentCode = "HV027", FullName = "Đỗ Thị AA", Gender = "Nữ", Email = "dothiaa@example.com", PhoneNumber = "0934567890", DateOfBirth = new DateTime(2000, 11, 14), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 28, StudentCode = "HV028", FullName = "Nguyễn Văn BB", Gender = "Nam", Email = "nguyenvanbb@example.com", PhoneNumber = "0922334455", DateOfBirth = new DateTime(1997, 1, 21), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 29, StudentCode = "HV029", FullName = "Lê Thị CC", Gender = "Nữ", Email = "lethicc@example.com", PhoneNumber = "0916543210", DateOfBirth = new DateTime(1999, 8, 13), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 30, StudentCode = "HV030", FullName = "Trần Văn DD", Gender = "Nam", Email = "tranvandd@example.com", PhoneNumber = "0909876543", DateOfBirth = new DateTime(1996, 6, 7), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 31, StudentCode = "HV031", FullName = "Vũ Thị EE", Gender = "Nữ", Email = "vuthiee@example.com", PhoneNumber = "0976543210", DateOfBirth = new DateTime(2000, 3, 19), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 32, StudentCode = "HV032", FullName = "Bùi Văn FF", Gender = "Nam", Email = "buivanff@example.com", PhoneNumber = "0922334455", DateOfBirth = new DateTime(1998, 10, 29), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 33, StudentCode = "HV033", FullName = "Nguyễn Thị GG", Gender = "Nữ", Email = "nguyenthigg@example.com", PhoneNumber = "0934567890", DateOfBirth = new DateTime(1997, 5, 22), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 34, StudentCode = "HV034", FullName = "Lê Văn HH", Gender = "Nam", Email = "levanhh@example.com", PhoneNumber = "0945678901", DateOfBirth = new DateTime(1999, 12, 11), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 35, StudentCode = "HV035", FullName = "Trương Thị II", Gender = "Nữ", Email = "truongthii@example.com", PhoneNumber = "0977654321", DateOfBirth = new DateTime(2000, 4, 4), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 36, StudentCode = "HV036", FullName = "Đỗ Văn JJ", Gender = "Nam", Email = "dovanjj@example.com", PhoneNumber = "0909871234", DateOfBirth = new DateTime(1996, 8, 16), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 37, StudentCode = "HV037", FullName = "Nguyễn Thị KK", Gender = "Nữ", Email = "nguyenthikk@example.com", PhoneNumber = "0912345678", DateOfBirth = new DateTime(1998, 1, 3), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 38, StudentCode = "HV038", FullName = "Lê Văn LL", Gender = "Nam", Email = "levanll@example.com", PhoneNumber = "0923456789", DateOfBirth = new DateTime(2001, 7, 29), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 39, StudentCode = "HV039", FullName = "Vũ Thị MM", Gender = "Nữ", Email = "vuthimm@example.com", PhoneNumber = "0934567890", DateOfBirth = new DateTime(1999, 6, 17), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 40, StudentCode = "HV040", FullName = "Bùi Văn NN", Gender = "Nam", Email = "buivannn@example.com", PhoneNumber = "0912345678", DateOfBirth = new DateTime(1995, 3, 12), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 41, StudentCode = "HV041", FullName = "Trần Thị OO", Gender = "Nữ", Email = "tranthioo@example.com", PhoneNumber = "0976543210", DateOfBirth = new DateTime(1997, 11, 4), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 42, StudentCode = "HV042", FullName = "Nguyễn Văn PP", Gender = "Nam", Email = "nguyenvanpp@example.com", PhoneNumber = "0945678901", DateOfBirth = new DateTime(1998, 9, 25), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 43, StudentCode = "HV043", FullName = "Lê Thị QQ", Gender = "Nữ", Email = "lethiqq@example.com", PhoneNumber = "0934567890", DateOfBirth = new DateTime(1996, 2, 8), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 44, StudentCode = "HV044", FullName = "Trương Văn RR", Gender = "Nam", Email = "truongvanrr@example.com", PhoneNumber = "0922334455", DateOfBirth = new DateTime(1999, 12, 20), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 45, StudentCode = "HV045", FullName = "Đỗ Thị SS", Gender = "Nữ", Email = "dothiss@example.com", PhoneNumber = "0908765432", DateOfBirth = new DateTime(2000, 6, 15), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 46, StudentCode = "HV046", FullName = "Nguyễn Thị TT", Gender = "Nữ", Email = "nguyenthitt@example.com", PhoneNumber = "0912345678", DateOfBirth = new DateTime(1998, 10, 7), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 47, StudentCode = "HV047", FullName = "Lê Văn UU", Gender = "Nam", Email = "levanuu@example.com", PhoneNumber = "0923456789", DateOfBirth = new DateTime(1996, 8, 24), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 48, StudentCode = "HV048", FullName = "Trần Thị VV", Gender = "Nữ", Email = "tranthivv@example.com", PhoneNumber = "0934567890", DateOfBirth = new DateTime(2000, 5, 5), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Inactive" },
                new Student { Id = 49, StudentCode = "HV049", FullName = "Bùi Văn WW", Gender = "Nam", Email = "buivanww@example.com", PhoneNumber = "0976543210", DateOfBirth = new DateTime(1999, 7, 11), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" },
                new Student { Id = 50, StudentCode = "HV050", FullName = "Nguyễn Thị XX", Gender = "Nữ", Email = "nguyenthixx@example.com", PhoneNumber = "0901234567", DateOfBirth = new DateTime(2001, 4, 20), EnrollmentDate = new DateTime(2024, 9, 1), Status = "Active" }

                );
            #endregion

            // Generate random string function
            static string GenerateRandomString()
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                int length = 6;
                StringBuilder result = new StringBuilder(length);
                Random random = new Random();

                for (int i = 0; i < length; i++)
                {
                    result.Append(chars[random.Next(chars.Length)]);
                }

                return result.ToString();
            }
        }
    }
}
