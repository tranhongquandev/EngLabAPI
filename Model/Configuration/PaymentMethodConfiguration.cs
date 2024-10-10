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
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MethodName).IsRequired().HasMaxLength(50);

            #region Seed Data
            builder.HasData(
                new PaymentMethod { Id = 1, MethodName = "Tiền mặt" },
                new PaymentMethod { Id = 2, MethodName = "Thẻ ghi nợ" },
                new PaymentMethod { Id = 3, MethodName = "Thẻ tính dụng" },
                new PaymentMethod { Id = 4, MethodName = "Chuyển khoản ngân hàng" },
                new PaymentMethod { Id = 5, MethodName = "Ví điện tử" }
            );
            #endregion
        }
    }
}
