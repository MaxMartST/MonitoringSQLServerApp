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
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddMvc(options => 
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add<ValidatorFilter>();
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());
            
            services.AddControllers();
            services.AddControllersWithViews();

            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            //services.AddTransient<IValidator<User>, UserValidator>();
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
            });

            ApplicationInitialize.Initialize(context);
        }
    }
}
