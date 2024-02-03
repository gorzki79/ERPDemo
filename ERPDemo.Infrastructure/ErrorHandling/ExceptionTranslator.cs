using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERPDemo.Infrastructure.ErrorHandling
{
    public class ExceptionTranslator : IExceptionTranslator
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public ExceptionTranslator(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public ErrorResponse Translate<TEx>(TEx exception)
            where TEx : Exception
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var translator = scope.ServiceProvider.GetService<IExceptionToResponseTranslator<TEx>>();

                if (translator == null)
                {
                    return new ErrorResponse(System.Net.HttpStatusCode.BadRequest, exception.Message);
                }
                return translator.Translate(exception);
            }
        }

        public ErrorResponse Translate(Exception exception)
        {
            Type exType = exception.GetType();
            MethodInfo translateExact = this.GetType().GetMethods().Single(m => m.Name == nameof(Translate) && m.IsGenericMethodDefinition);
            var genericTranslateMethod = translateExact.MakeGenericMethod(exType);

            return (ErrorResponse) genericTranslateMethod.Invoke(this, new[] { exception });
        }
    }
}
