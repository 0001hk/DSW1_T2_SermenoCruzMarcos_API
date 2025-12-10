using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DSW1_T2_SermenoCruzMarcos.Infrastructure.Persistence;
using DSW1_T2_SermenoCruzMarcos.Infrastructure.Repositories;
using DSW1_T2_SermenoCruzMarcos.Domain.Ports.Out;

namespace DSW1_T2_SermenoCruzMarcos.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var dbServer = configuration["DB_SERVER"];
            var dbDatabase = configuration["DB_DATABASE"];
            var dbUser = configuration["DB_USER"];
            var dbPassword = configuration["DB_PASSWORD"];

            var connectionString = $"Server={dbServer};Database={dbDatabase};User Id={dbUser};Password={dbPassword};";
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    connectionString,
                    new MySqlServerVersion(new Version(8, 0, 31)), 
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
            );

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}