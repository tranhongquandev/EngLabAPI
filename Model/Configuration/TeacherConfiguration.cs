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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TeacherCode).HasDefaultValue(GenerateRandomString());
            builder.Property(x => x.ImgUrl).HasMaxLength(255);
            builder.Property(x => x.FullName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Gender).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x => x.DateOfBirth);
            builder.Property(x => x.HireDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.EndDate);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            #region Seed Data
            builder.HasData(
                new Teacher { Id = 1, TeacherCode = "GV001", ImgUrl = "http://example.com/img1.jpg", FullName = "Nguyễn Văn A", Gender = "Nam", Email = "nguyenvana@example.com", PhoneNumber = "0901234567", Address = "123 Đường ABC, Hà Nội", DateOfBirth = new DateTime(1980, 5, 15), HireDate = new DateTime(2010, 1, 10), EndDate = null, IsActive = true },
                new Teacher { Id = 2, TeacherCode = "GV002", ImgUrl = "http://example.com/img2.jpg", FullName = "Trần Thị B", Gender = "Nữ", Email = "tranthib@example.com", PhoneNumber = "0912345678", Address = "456 Đường DEF, Hà Nội", DateOfBirth = new DateTime(1985, 8, 22), HireDate = new DateTime(2012, 4, 20), EndDate = null, IsActive = true },
                new Teacher { Id = 3, TeacherCode = "GV003", ImgUrl = "http://example.com/img3.jpg", FullName = "Lê Văn C", Gender = "Nam", Email = "levanc@example.com", PhoneNumber = "0923456789", Address = "789 Đường GHI, Hà Nội", DateOfBirth = new DateTime(1990, 3, 30), HireDate = new DateTime(2015, 6, 15), EndDate = null, IsActive = true },
                new Teacher { Id = 4, TeacherCode = "GV004", ImgUrl = "http://example.com/img4.jpg", FullName = "Nguyễn Thị D", Gender = "Nữ", Email = "nguyenthid@example.com", PhoneNumber = "0934567890", Address = "101 Đường JKL, Hà Nội", DateOfBirth = new DateTime(1988, 7, 10), HireDate = new DateTime(2018, 3, 25), EndDate = null, IsActive = true },
                new Teacher { Id = 5, TeacherCode = "GV005", ImgUrl = "http://example.com/img5.jpg", FullName = "Trương Văn E", Gender = "Nam", Email = "truongvane@example.com", PhoneNumber = "0945678901", Address = "202 Đường MNO, Hà Nội", DateOfBirth = new DateTime(1979, 11, 5), HireDate = new DateTime(2010, 7, 30), EndDate = null, IsActive = true },
                new Teacher { Id = 6, TeacherCode = "GV006", ImgUrl = "http://example.com/img6.jpg", FullName = "Bùi Thị F", Gender = "Nữ", Email = "buithif@example.com", PhoneNumber = "0956789012", Address = "303 Đường PQR, Hà Nội", DateOfBirth = new DateTime(1983, 9, 14), HireDate = new DateTime(2014, 5, 10), EndDate = null, IsActive = true },
                new Teacher { Id = 7, TeacherCode = "GV007", ImgUrl = "http://example.com/img7.jpg", FullName = "Đỗ Văn G", Gender = "Nam", Email = "dovang@example.com", PhoneNumber = "0967890123", Address = "404 Đường STU, Hà Nội", DateOfBirth = new DateTime(1991, 12, 21), HireDate = new DateTime(2016, 11, 15), EndDate = null, IsActive = true },
                new Teacher { Id = 8, TeacherCode = "GV008", ImgUrl = "http://example.com/img8.jpg", FullName = "Nguyễn Thị H", Gender = "Nữ", Email = "nguyenthih@example.com", PhoneNumber = "0978901234", Address = "505 Đường VWX, Hà Nội", DateOfBirth = new DateTime(1986, 4, 2), HireDate = new DateTime(2012, 9, 5), EndDate = null, IsActive = true },
                new Teacher { Id = 9, TeacherCode = "GV009", ImgUrl = "http://example.com/img9.jpg", FullName = "Lê Văn I", Gender = "Nam", Email = "levani@example.com", PhoneNumber = "0989012345", Address = "606 Đường YZA, Hà Nội", DateOfBirth = new DateTime(1990, 6, 18), HireDate = new DateTime(2018, 3, 25), EndDate = null, IsActive = true },
                new Teacher { Id = 10, TeacherCode = "GV010", ImgUrl = "http://example.com/img10.jpg", FullName = "Trần Thị J", Gender = "Nữ", Email = "tranthij@example.com", PhoneNumber = "0990123456", Address = "707 Đường BCD, Hà Nội", DateOfBirth = new DateTime(1985, 10, 7), HireDate = new DateTime(2015, 4, 12), EndDate = null, IsActive = true }
                );
            #endregion

        }

        //Generate random string function
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
