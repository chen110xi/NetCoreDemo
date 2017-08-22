using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDemo.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreDemo.Mapping.ManyToMany
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // 主键
            builder.HasKey(t => t.Id);

            // 属性
            builder.Property(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(50);
        }
    }
}
