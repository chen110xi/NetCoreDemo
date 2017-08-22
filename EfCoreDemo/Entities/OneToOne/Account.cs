namespace EfCoreDemo.Entities.OneToOne
{
    public class Account
    {
        /// <summary>
        /// 账户ID
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// 账户名
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual User User { get; set; }
    }
}
