using itwazzup.Services.LdapService.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Text;

namespace itwazzup.Services.LdapService
{

    public class LdapService : ILdapService
    {
        public LdapService()
        {
        }

        public bool Authenticate(string username, string password)
        {
            try
            {
                using (var adContext = new PrincipalContext(ContextType.Domain, "infotrack.com.au"))
                {
                    return adContext.ValidateCredentials(username, password);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
