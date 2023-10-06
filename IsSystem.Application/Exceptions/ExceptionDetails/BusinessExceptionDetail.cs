using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsSystem.Application.Exceptions.ExceptionDetails
{
    public class BusinessExceptionDetail: ProblemDetails
    {
        public BusinessExceptionDetail(string detail)
        {
            Title = "Rule";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest;
            Type = "";
        }
    }
}
