using System.Net;

namespace ERPDemo.Infrastructure.ErrorHandling
{
    public class ErrorResponse
    {
        public HttpStatusCode Status { get; }
        public object Data { get; }

        public ErrorResponse(HttpStatusCode status, object data)
        {
            Status = status;    
            Data = data;
        }
    }
}
