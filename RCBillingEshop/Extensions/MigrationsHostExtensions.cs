
using Microsoft.EntityFrameworkCore;
using RCBillingEshop.Infrastructure.DataStore;

namespace RCBillingEshop.API
{
    public static class MigrationsHostExtensions
    {
        public static async Task MigrateAsync(this IApplicationBuilder app)
        {
            using (var scope = ((IApplicationBuilder) app).ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<BillingDbContext>();
                await dbContext.Database.MigrateAsync();
            }
        }
    }
}
