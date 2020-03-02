using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static itwazzup.Api.Configurations.AutoMapper;
using static itwazzup.Api.Configurations.FluentValidation;
using static itwazzup.Api.Configurations.MediatR;
using static itwazzup.Api.Configurations.Mvc;
using static itwazzup.Api.Configurations.Swagger;
using static itwazzup.Api.Configurations.Db;
using itwazzup.Persistence.Context;
using itwazzup.Services.LdapService;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace itwazzup.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterEntityFramework(services, Configuration);
            RegisterSwagger(services);
            RegisterMediatR(services);
            RegisterAutoMapper(services);
            IMvcBuilder mvcBuilder = RegisterMvc(services);
            AddFluentValidation(mvcBuilder);
            services.AddSingleton<ILdapService, LdapService>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, itwazzupDbContext context)
        {
            Console.WriteLine("Current Environment");
            Console.WriteLine(env.EnvironmentName);
            ConfigureSwagger(app);
            ConfigureMvc(app);
            ConfigureDatabaseMigrations(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase(context);
            }
        }
    }
}