using ERPDemo.Application.Commands.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ValidationException = ERPDemo.Application.Commands.Validation.ValidationException;

namespace ERPDemo.Application
{
    public static class AppExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ValidationException).Assembly, ServiceLifetime.Transient);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            return services;
        }
    }
}
