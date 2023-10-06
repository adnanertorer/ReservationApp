using IsSystem.Application.Exceptions.ExceptionDetails;
using IsSystem.Application.Exceptions.Extensions;
using Microsoft.AspNetCore.Http;

namespace IsSystem.Application.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        private HttpResponse _response;
        public HttpResponse Response
        {
            get => _response ?? throw new ArgumentNullException(nameof(_response));
            set => _response = value;
        }
        protected override Task HandleException(BusinessException businessException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessExceptionDetail(businessException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            string details = new InternalServerExceptionDetail(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }
    }
}
