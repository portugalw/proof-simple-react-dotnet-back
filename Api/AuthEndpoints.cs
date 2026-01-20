using vendsys_api.Application.Services;

namespace vendsys_api.Api
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/authenticate", (
                LoginRequest request,
                IAuthService authService
            ) =>
            {
                var isValid = authService.Authenticate(
                    request.Username,
                    request.Password
                );

                return isValid
                    ? Results.Ok()
                    : Results.Unauthorized();
            });
        }
    }
}

public record LoginRequest(string Username, string Password);
