using vendsys_api.Domain.Interfaces;

namespace vendsys_api.Application.Services
{

    public class AuthService : IAuthService
    {
        private readonly ICredentialProvider _credentialProvider;

        public AuthService(ICredentialProvider credentialProvider)
        {
            _credentialProvider = credentialProvider;
        }

        public bool Authenticate(string username, string password)
        {
            return _credentialProvider.Validate(username, password);
        }
    }
}
