
using RCBillingEshop.Infrastructure.DataStore;

namespace RCBillingEshop.API
{
    internal static class MigrationsHostExtensions
    {
        internal static async Task TryMigrateAsync(this WebApplication app)
        {
            using (var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<BillingDbContext>();
                //dbContext.Database.Migrate();
            }
        }
    }
}
