using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using DSW1_T2_SermenoCruzMarcos.Application.Services.Interfaces;
using DSW1_T2_SermenoCruzMarcos.Application.Services;

namespace DSW1_T2_SermenoCruzMarcos.Application.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoanService, LoanService>();

            return services;
        }
    }
}