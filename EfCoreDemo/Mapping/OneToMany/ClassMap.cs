using Microsoft.EntityFrameworkCore;
using EfCoreDemo.Entities.OneToMany;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreDemo.Mapping.OneToMany
{
    public class ClassMap : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            // 主键
            builder.HasKey(t => t.ClassId);

            // 属性
            builder.Property(t => t.ClassId);
            builder.Property(t => t.ClassName).HasMaxLength(50);

            // 客制化表名称
            builder.ToTable("Class");

            // 客制化字段名称
            builder.Property(t => t.ClassId).HasColumnName("ClassId").IsRequired();
            builder.Property(t => t.ClassName).HasColumnName("ClassName").IsRequired();

            // 表关联关系设置,实现一个Class对多个User,Class为主体。
            builder
                .HasMany(classx => classx.Students)
                .WithOne(student => student.Class);
        }
    }
}
