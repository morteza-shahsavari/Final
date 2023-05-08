using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Security.Bootstrap;
using Shopping.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopMashtiHasan
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddScoped<Helper.CustomAuthenticator>();
            //Write in Cookie
            services.AddHttpContextAccessor();


            services.AddScoped<ICookieHelper, CookieHelper>();
            //Session Management
            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(30);
                opt.Cookie.HttpOnly = true;

                opt.Cookie.IsEssential = true;
            });
            services.AddScoped<Helper.ISessionHelper, SessionHelper>();

            services.ConfigureApplicationCookie(options => {

                options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        var requestPath = ctx.Request.Path;
                        if (requestPath.Value == "/")
                        {
                            ctx.Response.Redirect("/");
                        }
                        else if (requestPath.Value == "/Home/Contact")
                        {
                            ctx.Response.Redirect("/Home/AdminLogin");
                        }

                        return Task.CompletedTask;
                    }
                };

            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account/Login");
                    o.LogoutPath = new PathString("/Account/Logout");
                    o.AccessDeniedPath = new PathString("/Account/Login");
                    o.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });

            services.AddHsts(op =>
            {
                op.MaxAge = TimeSpan.FromDays(365);
                op.IncludeSubDomains = true;
            });

            var str = Configuration["ConnectionString"];
            var sSecurityConnectionString = Configuration["SecurityConnectionString"];
            BootStrap.WireUP(services, str);
            SecurityBootstrap.WireUp(services, sSecurityConnectionString);


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHsts();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
