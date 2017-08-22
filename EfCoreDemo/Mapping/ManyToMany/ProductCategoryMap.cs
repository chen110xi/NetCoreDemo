using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDemo.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreDemo.Mapping.ManyToMany
{
    public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            // 主键
            builder.HasKey(t => t.Id);

            // 属性
            builder.Property(t => t.Id).IsRequired();

            // 关系
            builder.HasOne(p => p.Product)
                .WithMany(p => p.ProductCategories).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Category)
                .WithMany(p => p.ProductCategories).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
