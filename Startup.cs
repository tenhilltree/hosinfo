using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using RazorSecond.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RazorSecond
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<HosDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("HosConnection")));
            services.AddDbContext<RecDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("RecConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            IMvcBuilder builder = services.AddRazorPages().AddRazorPagesOptions(options =>
                {
                    // options.Conventions.AuthorizePage("/Contact");
                    options.Conventions.AuthorizeFolder("/");
                    // options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
                    // options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
                });
#if DEBUG
            if (Env.IsDevelopment())
            {
                builder.AddRazorRuntimeCompilation();
            }
#endif

            services.Configure<IdentityOptions>(options =>
                {
                    // Password settings.
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequiredUniqueChars = 0;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = false;

                });

            services.ConfigureApplicationCookie(options =>
                {
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(2);

                    options.LoginPath = "/Identity/Account/Login";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                    options.SlidingExpiration = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapRazorPages();
            });
        }
    }
}
