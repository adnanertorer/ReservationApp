using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsSystem.Application.Exceptions.ExceptionDetails
{
    public class InternalServerExceptionDetail : ProblemDetails
    {
        public InternalServerExceptionDetail(string detail)
        {
            Title = "Internal Server Error";
            Detail = "Internal Server Error";
            Status = StatusCodes.Status500InternalServerError;
            Type = "";
        }
    }
}
