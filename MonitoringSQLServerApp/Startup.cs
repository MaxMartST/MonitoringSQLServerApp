using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonitoringSQLServer.Application;
using MonitoringSQLServer.Domain;
using MonitoringSQLServer.Infrastructure;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using FluentValidation;
using MonitoringSQLServerApp.ActionFilters;
using Microsoft.AspNetCore.Routing;
using AutoMapper;

namespace MonitoringSQLServerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            })
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
            services.AddScoped<ValidationFilterAttribute>();
            services.AddControllers();
            services.AddControllersWithViews();

            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseRouting();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name:"blocking",
                    template: "Statistics/{action}/{category?}");
            });

            ApplicationInitialize.Initialize(context);
        }
    }
}
