using Maanfee.Dashboard.Domain.DAL;
using Maanfee.Dashboard.Domain.Entities;
using Maanfee.Dashboard.Views.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Maanfee.Dashboard.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDashboardCompression(this IServiceCollection Services)
        {
            //Services.AddResponseCompression(opts =>
            //{
            //    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
            //        new[] { "application/octet-stream" });
            //});

            return Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
        }

        public static IServiceCollection AddDashboardAuthorization(this IServiceCollection Services)
        {
            #region - Authentication -

            Services.AddOptions();
            //Services.AddAuthorizationCore(options =>
            //{
            //    RegisterPermissionClaims(options);
            //});
            Services.AddScoped<CustomAuthenticationStateProvider>();
            //Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthenticationStateProvider>());
            //Services.AddScoped<JwtAuthenticationStateProvider>();

            #endregion

            Services.AddSingleton<HttpClient>();

            return Services;
        }

        public static IServiceCollection AddDashboardAuthorizationCSR(this IServiceCollection Services)
        {
            #region - Authentication -

            Services.AddOptions();
            //Services.AddAuthorizationCore(options =>
            //{
            //    RegisterPermissionClaims(options);
            //});
            Services.AddScoped<CustomAuthenticationStateProvider>();
            Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthenticationStateProvider>());
            //Services.AddScoped<JwtAuthenticationStateProvider>();

            #endregion

            return Services;
        }

        public static IServiceCollection AddDashboardDatabaseConfigurations(this IServiceCollection Services, IConfiguration Configuration)
        {
            var SQLServerConnectionString = Configuration.GetConnectionString("SQLServerConnection_DebugMode") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            #region - Configuring Database -

            Services.AddDbContext<_BaseContext_SQLServer>(options => options.UseSqlServer(SQLServerConnectionString));
            Services.AddDbContext<_BaseContext_InMemory>(options => options.UseInMemoryDatabase("InMemoryConnection"));
            Services.AddDbContext<_BaseContext_SQLite>(options => options.UseSqlite("Filename=SQLite_db.db"));

            Services.AddDatabaseDeveloperPageExceptionFilter();

            #endregion

            #region - Identity -

            Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                //options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.MaxFailedAccessAttempts = 5;  // ۵ تلاش ناموفق مجاز
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // ۱۵ دقیقه قفل
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = false;
            })
                .AddEntityFrameworkStores<_BaseContext_SQLServer>()
                .AddDefaultTokenProviders();

            #endregion

            #region - Configure Application Cookie -

            Services.ConfigureApplicationCookie(options =>
            {
                //options.Cookie.HttpOnly = false;
                //options.Events.OnRedirectToLogin = context =>
                //{
                //    context.Response.StatusCode = 401;
                //    return Task.CompletedTask;
                //};
                //options.ExpireTimeSpan = TimeSpan.FromMinutes(3600);

                // Cookie settings
                options.LoginPath = "/login";
                options.LogoutPath = "/login";
                options.AccessDeniedPath = "/login";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });

            #endregion

            return Services;
        }



    }
}
