using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Internal;

namespace IsSystem.Application.Exceptions.Extensions;

public static class ExceptionMiddleewareExtension
{
    public static void UseCustomExceptionMiddleware(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>();
}
