using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Context
{
    public class MyMigration
    {
        /// <summary>
        /// 1.数据库迁移升级
        /// </summary>
        public static void DoMigrate()
        {
            using (DemoContext db = new DemoContext())
            {
                try
                {
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    db.Database.Migrate();
                }
            }
        }

        /// <summary>
        /// 3.数据库迁移升级同时完成数据迁移
        /// </summary>
        public static void MigrateAndInitData()
        {
            DoMigrate();
        }

        /// <summary>
        /// 2.初始基础数据
        /// </summary>
        public static void InitBaseData()
        {
            //InitData();
            //InitDisposSystemOption();
            //InitDutyCheckAppraise();
            //InitDutyCheckTimePlan();
        }
    }
}
