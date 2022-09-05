
using Microsoft.EntityFrameworkCore;
using RCBillingEshop.Infrastructure.DataStore;

namespace RCBillingEshop.API.Extensions
{
    public static class MigrationsHostExtensions
    {
        public static async Task MigrateAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<BillingDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
