using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Models.Enteties;

namespace WebShop.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<ApplicationDbContext>();
                var config = serviceProvider.GetRequiredService<IConfiguration>();

                //db.Database.EnsureDeleted();
                //db.Database.Migrate();

                var adminPW = config["AdminPW"];

                try
                {
                   
                    await SeedData.InitAsync(db, serviceProvider, adminPW);
                }
                catch (Exception e)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(string.Join(" ", e.Message));
                    //throw;
                }
            }

            return app;
        }
    }
}
