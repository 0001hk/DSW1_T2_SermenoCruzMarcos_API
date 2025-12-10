using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DSW1_T2_SermenoCruzMarcos.Infrastructure.Persistence;

namespace DSW1_T2_SermenoCruzMarcos.Infrastructure.Extensions
{
    public static class MigrationExtensions 
    {
        public static void ApplyMigrations(this IHost host) 
        {
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate(); 
        }
    }
}