using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.Annotations;
using MediatR;
using itwazzup.Services.LdapService;

namespace itwazzup.Application.Account.Queries.GetAccountLogin
{
    /// <summary>
    /// Query
    /// </summary>
    [JsonSchema("GetAccountLoginQuery")]
    public class Query : IRequest<bool>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Query Handler
    /// </summary>
    public class QueryHandler : IRequestHandler<Query, bool>
    {
        private ILdapService ldapService;

        public QueryHandler(ILdapService ldapService)
        {
            this.ldapService = ldapService;
        }


        public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ldapService.Authenticate(request.Username, request.Password));
        }
    }
}