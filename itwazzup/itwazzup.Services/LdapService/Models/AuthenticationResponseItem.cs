namespace itwazzup.Services.LdapService.Models
{
    public class AuthenticationResponseItem
    {
        public bool Success { get; private set; }
        public string Fullname { get; private set; }

        public AuthenticationResponseItem(bool success, string fullname)
        {
            Success = success;

            Fullname = fullname;
        }
    }
}
