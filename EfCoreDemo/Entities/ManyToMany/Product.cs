using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreDemo.Entities.ManyToMany
{
    public class Product
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 分类集合
        /// </summary>
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
