using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models = itwazzup.Application.CampaignItem.Models;
using Queries = itwazzup.Application.CampaignItem.Queries;
using Commands = itwazzup.Application.CompaignItem.Commands;

namespace itwazzup.Api.Controllers
{
    [Route("api/[controller]")]
    public class CampaignItemController : MediatorController {

        [HttpGet]
        [Description("Get list of compaign items, given a compaign ID.")]
        public async Task<ActionResult<Models.CampaignItemModel>> Get([FromQuery] int campaignId)
        {
            var result = await Mediator.Send(new Queries.GetCampaignItemList.Query()
            {
                CompaignId = campaignId
            });

            return Ok(result);
        }

        [HttpPost]
        [Description("Cast vote")]
        public async Task<ActionResult<string>> Vote([FromBody] Commands.CastVote.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}