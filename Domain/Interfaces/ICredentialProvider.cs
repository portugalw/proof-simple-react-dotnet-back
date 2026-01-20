namespace vendsys_api.Domain.Interfaces
{
    public interface ICredentialProvider
    {
        bool Validate(string username, string password);
    }
}
