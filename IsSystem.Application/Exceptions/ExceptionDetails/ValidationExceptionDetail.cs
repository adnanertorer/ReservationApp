using IsSystem.Application.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsSystem.Application.Exceptions.ExceptionDetails
{
    public class ValidationExceptionDetail: ProblemDetails
    {
        public IEnumerable<ValidationExceptionModel> Errors { get; set; }
        public ValidationExceptionDetail(IEnumerable<ValidationExceptionModel> errors)
        {
            Title = "Validation error(s)";
            Detail = "One or more validation errors occurred.";
            Errors = errors;
            Status = StatusCodes.Status400BadRequest;
            Type = "";
        }
    }
}
