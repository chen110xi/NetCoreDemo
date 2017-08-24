using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using EfCoreDemo.Context;
using EfCoreDemo.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;

namespace EfCoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.Configure<CatalogSettings>(Configuration);

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "eShopOnContainers - Catalog HTTP API",
                    Version = "v1",
                    Description = "The Catalog Microservice HTTP API. This is a Data-Driven/CRUD microservice sample",
                    TermsOfService = "Terms Of Service"
                });
            });

            // 添加DB配置
            services.AddDbContext<DemoContext>();


            var container = new ContainerBuilder();
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DemoContext context)
        {
            //日志
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddProvider(new MyFilteredLoggerProvider());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });

            app.UseMvc();

            //创建DB
            new MyMigration().InitializeAsync(context);

            //var context1 = (DemoContext)app.ApplicationServices.GetService(typeof(DemoContext));

            WaitForSqlAvailabilityAsync(context, loggerFactory, app, env).Wait();
        }

        private async Task WaitForSqlAvailabilityAsync(DemoContext ctx, ILoggerFactory loggerFactory, IApplicationBuilder app, IHostingEnvironment env, int retries = 0)
        {
            var logger = loggerFactory.CreateLogger(nameof(Startup));
            var policy = CreatePolicy(retries, logger, nameof(WaitForSqlAvailabilityAsync));
            await policy.ExecuteAsync(async () =>
            {
                //await CatalogContextSeed.SeedAsync(app, env, loggerFactory);
            });

        }
        private Policy CreatePolicy(int retries, ILogger logger, string prefix)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogTrace($"[{prefix}] Exception {exception.GetType().Name} with message ${exception.Message} detected on attempt {retry} of {retries}");
                    }
                );
        }
    }
}
