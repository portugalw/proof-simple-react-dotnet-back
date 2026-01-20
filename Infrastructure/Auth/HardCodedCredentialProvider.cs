namespace vendsys_api.Infrastructure.Auth
{
    using Domain.Interfaces;

    public class HardcodedCredentialProvider : ICredentialProvider
    {
        private const string USER = "vendsys";
        private const string PASS = "NFsZGmHAGWJSZ#RuvdiV";

        public bool Validate(string username, string password)
        {
            return username == USER && password == PASS;
        }
    }

}
