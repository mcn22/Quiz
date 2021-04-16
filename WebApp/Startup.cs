using EditorialMvc.DataAccess.Data;
using EditorialMvc.DataAccess.Repositorio;
using EditorialMvc.DataAccess.Repositorio.IRepositorio;
using EditorialMvc.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditorialMvc
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
            services.AddDbContext<ApplicationDbContext>
                (
                    options =>
                        options.UseSqlServer
                            (Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddScoped<IUnidadTrabajo, UnidadTrabajo>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.ConfigureApplicationCookie
              (
                options =>
                {
                    options.LoginPath = "/Identity/Account/Login";
                    options.LogoutPath = "/Identity/Account/Logout";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                }
              );

            services.AddAuthentication().AddFacebook(options =>
                {
                    options.AppId = "1575719865965523";
                    options.AppSecret = "dbbb14762e78bf8834b79634b259f892";
                }
              );


            services.AddAuthentication().AddGoogle(options =>
              {
                  //IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
                  options.ClientId = "906120752235-7b8oivmq4fsrhe1469qsg44jkn027jg0.apps.googleusercontent.com";
                  options.ClientSecret = "ZvEa2vKwK60U0WFF4O6DK5t4";
              });

            services.Configure<SendGridOptions>(Configuration.GetSection(SendGridOptions.Section));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Cliente}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
