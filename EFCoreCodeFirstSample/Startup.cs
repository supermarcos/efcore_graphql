using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api_ef_experiment.Extensions;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using EFCoreCodeFirstSample.Models.DataManager;
using GraphiQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Extensions.Logging;
using GraphQL.Types;
using GraphQL;

namespace api_ef_experiment
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureLoggerService();
            services.AddDbContext<EmployeeContext>(opts => opts.UseNpgsql(Configuration["ConnectionString:EmployeeDB"]));
            services.AddScoped<IEmployeeRepository<Employee>, EmployeeManager>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IEmployeeRepository<Employee>, EmployeeManager>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<EmployeesQuery>();
            services.AddSingleton<EmployeesMutation>();
            services.AddSingleton<EmployeeType>();
            services.AddSingleton<EmployeeInputType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new EmployeesSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
            });

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseStaticFiles();
            app.UseGraphiQl(); // browsing to the default url (https://localhost:44364/graphql) you get to the graphiql IDE
            app.UseMvc();
            // db.EnsureSeedData();
        }
    }
}