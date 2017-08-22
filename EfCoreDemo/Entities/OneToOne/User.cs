using System;
using EfCoreDemo.Entities.OneToMany;

namespace EfCoreDemo.Entities.OneToOne
{
    public class User
    {
        /// <summary>
        /// 账户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 账户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 电子信箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// 账号信息
        /// </summary>
        public Account Account { get; set; }
    }
}
