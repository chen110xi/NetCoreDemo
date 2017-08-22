using EfCoreDemo.Entities.OneToOne;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreDemo.Mapping.OneToOne
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {            
            // 主键
            builder.HasKey(t => t.UserId);

            // 属性
            builder.Property(t => t.UserId);
            builder.Property(t => t.UserName).HasMaxLength(50);
            builder.Property(t => t.Email).HasMaxLength(100);

            // 客制化表名称
            builder.ToTable("User");

            // 客制化字段名称
            builder.Property(t => t.UserId).HasColumnName("AccountID").IsRequired();
            builder.Property(t => t.UserName).HasColumnName("UserName").IsRequired();
            builder.Property(t => t.Email).HasColumnName("Email").IsRequired();
            builder.Property(t => t.RegisterDate).HasColumnName("RegisterDate").IsRequired();

            // 表关联关系设置,实现一个User对一个Account,User为主体。
            builder
                .HasOne(user => user.Account)
                .WithOne(accout => accout.User);
        }
    }
}
