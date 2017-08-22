using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreDemo.Entities.ManyToMany
{
    public class ProductCategory
    {
        public Product Product { get; set; }
        public Category Category { get; set; }
        public Guid Id { get; internal set; }
    }
}
