using ERPDemo.Core.Exceptions;
using System.Net;

namespace ERPDemo.Infrastructure.ErrorHandling
{
    public class InvalidTruckStatusUpdateExceptionToResponseTranslator : IExceptionToResponseTranslator<InvalidTruckStatusUpdateException>
    {
        public ErrorResponse Translate(InvalidTruckStatusUpdateException exception)
        {
            return new ErrorResponse(
                HttpStatusCode.UnprocessableEntity,
                new
                {
                    Message = $"Invalid status update from '{exception.CurrentStatus.Name}' to '{exception.AttemptedStatus.Name}'"
                });
        }
    }
}
