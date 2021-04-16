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
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                    options.AppId = "496519634709007";
                    options.AppSecret = "fcc2dc274927e17dde496aa9b0f41c6f";
                }
              );


            //services.AddAuthentication().AddGoogle(options =>
            // {
            //      //IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
            //     options.ClientId = "906120752235-7b8oivmq4fsrhe1469qsg44jkn027jg0.apps.googleusercontent.com";
            //      options.ClientSecret = "ZvEa2vKwK60U0WFF4O6DK5t4";
            //  });

            services.Configure<SendGridOptions>(Configuration.GetSection(SendGridOptions.Section));


            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(options => {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                        {
                            new CultureInfo("es"),
                            new CultureInfo("en"),
                        };
                options.DefaultRequestCulture = new RequestCulture("es");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {



            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            //var supportedCultures = new[] { "es", "en"};
            //var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
            //    .AddSupportedCultures(supportedCultures)
            //    .AddSupportedUICultures(supportedCultures);

            //app.UseRequestLocalization(localizationOptions);

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
