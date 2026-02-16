using Maanfee.Dashboard.Domain.DAL;
using Maanfee.Dashboard.Services.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Maanfee.Dashboard.Services
{
    public static class DatabaseConfigureExtensions
    {
        public static IApplicationBuilder AddServerConfigurations(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                var scope = app.Services.CreateScope();
                var SQLServerContext = scope.ServiceProvider.GetRequiredService<_BaseContext_SQLServer>();
                //var SQLiteContext = scope.ServiceProvider.GetRequiredService<_BaseContext_SQLite>();

                DatabaseCreating<_BaseContext_SQLServer>(SQLServerContext);
                //DatabaseCreating<_BaseContext_SQLite>(SQLiteContext);

                SQLServerDataInitializer.Initialize(SQLServerContext);
                //    //SQLiteDataInitializer.Initialize(SQLiteContext);
            }

            //app.UseResponseCompression();  // فشرده‌سازی

            ////app.UseAuthentication();    // اول احراز هویت
            ////app.UseAuthorization();     // سپس مجوزدهی

            return app;
        }

        private static void DatabaseCreating<TContext>(TContext context) where TContext : DbContext
        {
            context.Database.EnsureCreated();
        }
    }
}
