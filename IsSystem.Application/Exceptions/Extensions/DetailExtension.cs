using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IsSystem.Application.Exceptions.Extensions
{
    public static class DetailExtension
    {
        public static string AsJson<T>(this T details) where T : ProblemDetails => JsonSerializer.Serialize(details);
    }
}
