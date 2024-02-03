using ERPDemo.Core.Repositories;
using ERPDemo.Persistence.Data.Entities;
using ERPDemo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERPDemo.Persistence
{
    public static class AppExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContextPool<ErpDemoDbContext>(options =>
            {
                var serviceProvider = services.BuildServiceProvider();
                IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();

                options.EnableSensitiveDataLogging(configuration.GetValue<bool>("SqlLogSensitiveData"));
                options.UseSqlServer(configuration.GetConnectionString("ERPDb"));
            });

            services.AddTransient<ITruckRepository, TruckRepository>();

            return services;
        }
    }
}
