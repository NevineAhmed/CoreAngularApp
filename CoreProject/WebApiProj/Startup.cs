using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisinessLay.IdentityModels;
using DataAccessLay;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceLay;

namespace WebApiProj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContextPool<Dcontext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser,IdentityRole>(options =>
             {
                 options.Password.RequiredLength = 6;
                 options.Password.RequireDigit = true;
                 options.Password.RequireUppercase = true;
                 options.Password.RequireLowercase = true;
                 options.Password.RequireNonAlphanumeric = true;
                 options.Password.RequiredUniqueChars = 0;
                 options.SignIn.RequireConfirmedEmail = true;
                 options.Lockout.MaxFailedAccessAttempts = 4;
                 options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);


             })
                .AddEntityFrameworkStores<Dcontext>()
                .AddDefaultTokenProviders();
           
            services.AddTransient(typeof(Irepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IUnitOWork), typeof(UnitOWork));
            services.AddTransient(typeof(DbContext),typeof(Dcontext));
            services.AddTransient(typeof(CourseService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
