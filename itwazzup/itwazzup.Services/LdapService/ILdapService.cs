namespace itwazzup.Services.LdapService
{
    public interface ILdapService
    {
        bool Authenticate(string username, string password);
    }
}