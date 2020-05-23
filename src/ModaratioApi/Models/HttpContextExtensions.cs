
using Microsoft.AspNetCore.Http;

public static class HttpContextExtensions
{
    public static string GetUserId(this HttpContext httpContext)
    {
        return httpContext?.User.FindFirst("sub")?.Value;
    }
}