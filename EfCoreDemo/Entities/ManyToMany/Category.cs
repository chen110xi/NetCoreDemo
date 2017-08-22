using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreDemo.Entities.ManyToMany
{
    public class Category
    {
        /// <summary>
        /// 分类编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商品集合
        /// </summary>
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
