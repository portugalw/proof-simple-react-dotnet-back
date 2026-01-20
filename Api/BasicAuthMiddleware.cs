using System.Text;
using vendsys_api.Application.Services;

namespace vendsys_api.Api
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // MIDDLEWARE to validate credential whem from upload route
        public async Task InvokeAsync(
            HttpContext context,
            IAuthService authService
        )
        {
            if (!context.Request.Path.StartsWithSegments("/dex"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("Authorization", out var header))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            if (!header.ToString().StartsWith("Basic "))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var encoded = header.ToString().Replace("Basic ", "");
            var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
            var parts = decoded.Split(':');

            if (parts.Length != 2 ||
                !authService.Authenticate(parts[0], parts[1]))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await _next(context);
        }
    }
}
