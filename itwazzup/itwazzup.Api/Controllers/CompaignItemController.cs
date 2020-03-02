using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models = itwazzup.Application.CampaignItem.Models;
using Queries = itwazzup.Application.CampaignItem.Queries;

namespace itwazzup.Api.Controllers
{
    [Route ("api/[controller]")]
    public class CompaignItemController : MediatorController {

        [HttpGet]
        [Description("Get list of compaign items, given a compaign ID.")]
        public async Task<ActionResult<Models.CampaignItemModel>> Get([FromQuery] int campaignId)
        {
            var result = await Mediator.Send(new Queries.GetCampaignItemList.Query() {
                CompaignId = campaignId
            });

            return Ok(result);
        }
    }
}