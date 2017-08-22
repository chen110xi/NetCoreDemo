using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDemo.Entities.OneToOne;

namespace EfCoreDemo.Entities.OneToMany
{
    public class Class
    {
        /// <summary>
        /// 班级ID
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public List<Student> Students { get; set; }
    }
}
