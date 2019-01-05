using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3.Data;
using WebApplication3.Model;
using WebApplication3.Model.Cart;
using WebApplication3.Model.SQl;
using WebStore.DAL;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebApplication3
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<WebStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IEmployeeData,EmployeeDataList>();
            services.AddTransient<IProductData, SQLProductData>();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<WebStoreContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IOrderService,SqlOrderService>();

            services.Configure<IdentityOptions>(options =>
            {
                
                options.Password.RequiredLength = 6;
               

                
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath =
                    "/Account/Login"; 
                options.LogoutPath =
                    "/Account/Logout"; 
                options.AccessDeniedPath =
                    "/Account/AccessDenied"; 
                options.SlidingExpiration = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICartService, CookieCartService>();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
