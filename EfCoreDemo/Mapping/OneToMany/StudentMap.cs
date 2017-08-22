using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDemo.Entities.OneToMany;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreDemo.Mapping.OneToMany
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // 主键
            builder.HasKey(t => t.StudentId);

            // 属性
            builder.Property(t => t.StudentId);
            builder.Property(t => t.StudentName).HasMaxLength(50);
            
        }
    }
}
