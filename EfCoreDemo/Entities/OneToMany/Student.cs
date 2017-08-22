using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreDemo.Entities.OneToMany
{
    public class Student
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// 学生名称
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 班级信息
        /// </summary>
        public Class Class { get; set; }
    }
}
