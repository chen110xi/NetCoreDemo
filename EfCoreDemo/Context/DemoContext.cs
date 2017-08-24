using System;
using System.Linq;
using System.Reflection;
using EfCoreDemo.Entities;
using EfCoreDemo.Entities.ManyToMany;
using EfCoreDemo.Entities.OneToMany;
using EfCoreDemo.Entities.OneToOne;
using EfCoreDemo.Mapping;
using EfCoreDemo.Mapping.OneToOne;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Context
{
    public class DemoContext : DbContext
    {
        static DemoContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Sql Server
            //var connection = @"Server = 192.168.18.58; User ID=sa; Password=aebell; Database = AllInOne; MultipleActiveResultSets=true;"; /*MultipleActiveResultSets=true;*/
            //var connection = @"Server = 192.168.1.30\sql2012; User ID=sa; Password=admin123!@#; Database = DemoDb; MultipleActiveResultSets=true;";
            var connection = @"Server=tcp:127.0.0.1;Initial Catalog=DemoDb;User Id=sa;Password=admin123!@#";

            optionsBuilder.UseSqlServer(connection);

            //PostgreSql
            //var connection = "User ID=postgres;Host=192.168.18.68;Password=123;Port=5432;Database=AllInOne9;Pooling=true;";
            //var connection = GlobalSetting.ConnectionString;
            //optionsBuilder.UseNpgsql(connection);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasPostgresExtension("uuid-ossp"); //针对PostgreSql

            base.OnModelCreating(modelBuilder);

            // Interface that all of our Entity maps implement
            var mappingInterface = typeof(IEntityTypeConfiguration<>);

            // Types that do entity mapping
            var mappingTypes = typeof(DemoContext).GetTypeInfo().Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));

            // Get the generic Entity method of the ModelBuilder type
            var entityMethod = typeof(ModelBuilder).GetMethods()
                .Single(x => x.Name == "Entity" &&
                             x.IsGenericMethod &&
                             x.ReturnType.Name == "EntityTypeBuilder`1");

            foreach (var mappingType in mappingTypes)
            {
                // Get the type of entity to be mapped
                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();

                // Get the method builder.Entity<TEntity>
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);

                // Invoke builder.Entity<TEntity> to get a builder for the entity to be mapped
                var entityBuilder = genericEntityMethod.Invoke(modelBuilder, null);

                // Create the mapping type and do the mapping
                var mapper = Activator.CreateInstance(mappingType);
                mapper.GetType().GetMethod("Configure").Invoke(mapper, new[] { entityBuilder });
            }

        }
        
    }
}
