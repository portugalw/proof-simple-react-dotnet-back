namespace vendsys_api.Application.Services
{
    public interface IAuthService
    {
        bool Authenticate(string username, string password);
    }
}