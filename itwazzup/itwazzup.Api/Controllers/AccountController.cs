using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Commands = itwazzup.Application.Account.Commands;
//using Models = itwazzup.Application.Account.Models;
using Queries = itwazzup.Application.Account.Queries;

namespace itwazzup.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : MediatorController
    {

        [HttpPost]
        [Description("Your endpoint description goes here.")]
        public async Task<ActionResult<bool>> Get([FromBody] Queries.GetAccountLogin.Query query)
        {
            var result = await Mediator.Send(query);
            if (result == false)
                return NotFound();
            return Ok(result);
        }
    }
}