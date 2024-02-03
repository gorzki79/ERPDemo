using ERPDemo.Infrastructure.ErrorHandling;
using ERPDemo.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ERPDemo.Infrastructure
{
    public static class AppExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPersistence();

            services.AddExceptionToResponseTranslators();
            services.AddTransient<ErrorHandlerMiddleware>();
            services.AddSingleton<IExceptionTranslator, ExceptionTranslator>();
            return services;
        }

        public static IServiceCollection AddExceptionToResponseTranslators(this IServiceCollection services)
        {
            services.Scan(s =>
             s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                 .AddClasses(c => c.AssignableTo(typeof(IExceptionToResponseTranslator<>)))
                 .AsImplementedInterfaces()
                 .WithTransientLifetime());

            return services;
        }


        public static void UseInfrastructure(this IApplicationBuilder builder)
            => builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}
