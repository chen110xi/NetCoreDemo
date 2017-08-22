using EfCoreDemo.Entities.OneToOne;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreDemo.Mapping.OneToOne
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // 主键
            builder.HasKey(t => t.AccountId);

            // 属性
            builder.Property(t => t.AccountName).HasMaxLength(50);
            builder.Property(t => t.Password).HasMaxLength(100);

            // 客制化表名称
            builder.ToTable("Account");

            // 客制化字段名称
            builder.Property(t => t.AccountId).HasColumnName("AccountID").IsRequired();
            builder.Property(t => t.AccountName).HasColumnName("AccountName").IsRequired();
            builder.Property(t => t.Password).HasColumnName("Password").IsRequired();
        }
    }
}
