using InertiaSparkTest.Application.Database;
using InertiaSparkTest.Application.Events.Listeners;
using InertiaSparkTest.Application.Models;
using InertiaSparkTest.Application.Services.Auth;
using InertiaSparkTest.Application.Services;
using Spark.Library.Database;
using Spark.Library.Logging;
using Coravel;
using Microsoft.AspNetCore.Components.Authorization;
using Spark.Library.Auth;
using InertiaSparkTest.Application.Tasks;
using Spark.Library.Mail;
using Microsoft.AspNetCore.Authentication.Cookies;
using InertiaCore;
using InertiaCore.Extensions;

namespace InertiaSparkTest.Application.Startup
{
    public static class AppServiceRegistration
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllersWithViews();
			services.AddCustomServices();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDatabase<DatabaseContext>(config);
            services.AddLogger(config);
            services.AddAuthorization(config, new string[] { CustomRoles.Admin, CustomRoles.User });
            services.AddInertiaAuthentication<ICookieService>(config);
            services.AddTaskServices();
            services.AddScheduler();
            services.AddQueue();
            services.AddEventServices();
            services.AddEvents();
            services.AddMailer(config);
            return services;
        }

        private static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // add custom services
            services.AddScoped<UsersService>();
            services.AddScoped<RolesService>();
            services.AddScoped<IExampleService, ExampleService>();
            services.AddScoped<ICookieService, CookieService>();
            services.AddScoped<AuthenticationStateProvider, SparkAuthenticationStateProvider>();
            return services;
        }

        private static IServiceCollection AddEventServices(this IServiceCollection services)
        {
            // add custom events here
            services.AddTransient<EmailNewUser>();
            return services;
        }

        private static IServiceCollection AddTaskServices(this IServiceCollection services)
        {
            // add custom background tasks here
            services.AddTransient<ExampleTask>();
            return services;
        }

        public static IServiceCollection AddInertiaAuthentication<T>(this IServiceCollection services, IConfiguration config) where T : ICookieService
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.SlidingExpiration = false;
                    options.LoginPath = "/login";
                    options.LogoutPath = "/logout";
                    //options.AccessDeniedPath = new PathString("/Home/Forbidden/");
                    options.Cookie.Name = ".blazor.spark.cookie";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnValidatePrincipal = context =>
                        {
                            var cookieValidatorService = context.HttpContext.RequestServices.GetRequiredService<T>();
                            return cookieValidatorService.ValidateAsync(context);
                        },
                        OnRedirectToLogin = context =>
                        {
                            if (context.Response.StatusCode == 401 && bool.TryParse(context.Request.Headers["X-Inertia"], out _))
                            {
                                context.Response.Clear();
                                context.Response.Headers.Location = "/login";
                                context.Response.StatusCode = StatusCodes.Status302Found;
                                return Task.FromResult(0);
                            }
                            context.Response.Redirect(context.RedirectUri);
                            return Task.FromResult(0);
                        }
                    };
                });
            return services;
        }
    }
}
