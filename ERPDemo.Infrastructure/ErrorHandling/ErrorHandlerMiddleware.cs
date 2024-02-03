using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace ERPDemo.Infrastructure.ErrorHandling
{
    class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> logger;
        private readonly IExceptionTranslator exceptionTranslationDispatcher;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, IExceptionTranslator exceptionTranslationDispatcher)
        {
            this.logger = logger;
            this.exceptionTranslationDispatcher = exceptionTranslationDispatcher;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, exception.Message);
                await HandleErrorAsync(context, exception);
            }
        }

        private async Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var errorResponse = this.exceptionTranslationDispatcher.Translate(exception);
            context.Response.StatusCode = (int)(errorResponse?.Status ?? HttpStatusCode.BadRequest);

            var data = errorResponse?.Data;

            if (data is { })
            {
                context.Response.ContentType = "application/json";
            }

            string responseBody = data is null ? "Unexpected error has occurred while processing your request." : JsonConvert.SerializeObject(data);
            await context.Response.WriteAsync(responseBody);
        }
    }
}
