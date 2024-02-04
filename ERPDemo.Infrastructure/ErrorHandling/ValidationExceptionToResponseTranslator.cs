using ERPDemo.Application.Commands.Validation;
using System.Net;

namespace ERPDemo.Infrastructure.ErrorHandling
{
    public class ValidationExceptionToResponseTranslator : IExceptionToResponseTranslator<ValidationException>
    {
        public ErrorResponse Translate(ValidationException exception)
        {
            var status = HttpStatusCode.UnprocessableEntity;
            return new ErrorResponse(status, new { Message = "Validation failed.", Errors = exception.Errors });
        }
    }
}
