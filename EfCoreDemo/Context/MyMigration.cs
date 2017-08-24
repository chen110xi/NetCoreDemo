using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDemo.Entities.ManyToMany;
using EfCoreDemo.Entities.OneToMany;
using EfCoreDemo.Entities.OneToOne;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Context
{
    public class MyMigration
    {
        public void InitializeAsync(DemoContext context)
        {
            MigrateAndInitData(context);
        }

        /// <summary>
        /// 1.数据库迁移升级
        /// </summary>
        public void DoMigrate(DemoContext context)
        {
            using (DemoContext db = new DemoContext())
            {
                try
                {
                    var migrations = context.Database.GetPendingMigrations();       //获取未应用的Migrations，不必要，MigrateAsync方法会自动处理
                    context.Database.Migrate();                                     //根据Migrations修改/创建数据库
                }
                catch (Exception ex)
                {
                    db.Database.Migrate();
                }
            }
        }

        /// <summary>
        /// 2.初始基础数据
        /// </summary>
        public void InitBaseData(DemoContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                //一对一
                context.Accounts.RemoveRange(context.Accounts.ToList());
                context.Users.RemoveRange(context.Users.ToList());
                context.SaveChanges();

                //添加用户，主表
                var user1 = context.Users.Add(new User()
                {
                    UserName = "晨曦1",
                    Email = "chen110xi@qq.com",
                    RegisterDate = DateTime.Now
                });
                var user2 = context.Users.Add(new User()
                {
                    UserName = "晨曦2",
                    Email = "chen110xi@qq.com",
                    RegisterDate = DateTime.Now
                });
                context.SaveChanges();

                //加添账号，从表
                context.Accounts.Add(new Account() { AccountName = "晨曦账号1-1", Password = "1", User = user1.Entity });

                context.Accounts.Add(new Account() { AccountName = "晨曦账号2-1", Password = "1", User = user2.Entity });
                context.Accounts.Add(new Account() { AccountName = "晨曦账号2-2", Password = "1", User = user2.Entity });
                context.SaveChanges();

                //============================================================================================================
                //一对多
                context.Students.RemoveRange(context.Students.ToList());
                context.Classes.RemoveRange(context.Classes.ToList());
                context.SaveChanges();

                //添加班级，主表
                var class1 = context.Classes.Add(new Class() { ClassName = "一班" });
                var class2 = context.Classes.Add(new Class() { ClassName = "二班" });
                context.SaveChanges();

                //添加学生，从表
                context.Students.Add(new Student() { StudentName = "张三", Class = class1.Entity });
                context.Students.Add(new Student() { StudentName = "李四", Class = class1.Entity });

                context.Students.Add(new Student() { StudentName = "王五", Class = class2.Entity });
                context.Students.Add(new Student() { StudentName = "赵六", Class = class2.Entity });
                context.SaveChanges();

                //============================================================================================================
                //多对多
                context.ProductCategories.RemoveRange(context.ProductCategories.ToList());
                context.Categories.RemoveRange(context.Categories.ToList());
                context.Products.RemoveRange(context.Products.ToList());
                context.SaveChanges();

                //添加商品，主表
                var prod1 = context.Products.Add(new Product() { Name = "商品一" });
                var prod2 = context.Products.Add(new Product() { Name = "商品二" });
                context.SaveChanges();

                //添加分类，主表
                var category1 = context.Categories.Add(new Category() { Name = "分类一" });
                var category2 = context.Categories.Add(new Category() { Name = "分类二" });
                context.SaveChanges();

                //添加商品分类，从表
                context.ProductCategories.Add(new ProductCategory() { Category = category1.Entity, Product = prod1.Entity });
                context.ProductCategories.Add(new ProductCategory() { Category = category1.Entity, Product = prod2.Entity });

                context.ProductCategories.Add(new ProductCategory() { Category = category2.Entity, Product = prod1.Entity });
                context.ProductCategories.Add(new ProductCategory() { Category = category2.Entity, Product = prod2.Entity });
                context.SaveChanges();

                transaction.Commit();
            }
        }

        /// <summary>
        /// 3.数据库迁移升级同时完成数据迁移
        /// </summary>
        public void MigrateAndInitData(DemoContext context)
        {
            DoMigrate(context);
            InitBaseData(context);
        }
    }
}
