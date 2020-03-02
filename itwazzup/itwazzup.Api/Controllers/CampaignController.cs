using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commands = itwazzup.Application.Campaign.Commands;
using Models = itwazzup.Application.Campaign.Models;
using Queries = itwazzup.Application.Campaign.Queries;

namespace itwazzup.Api.Controllers
{
    [Route("api/campaign")]
    public class CampaignController : MediatorController
    {

        [HttpPost]
        [Description("Create a new campaign.")]
        public async Task<ActionResult<Models.CampaignModel>> CreateCampaign([FromBody] Commands.Create.Command createCampaign)
        {
            var result = await Mediator.Send(createCampaign);
            return Ok(result);
        }

        [HttpGet]
        [Description("Returns a list of campaigns.")]
        public async Task<ActionResult<Models.CampaignModel>> GetCampaignList([FromQuery] bool? isClosed = null)
        {
            var result = await Mediator.Send(new Queries.GetCampaignList.Query()
            {
                IsClosed = isClosed
            });
            return Ok(result);
        }

    }
}