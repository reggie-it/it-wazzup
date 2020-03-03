using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.Annotations;
using MediatR;
using itwazzup.Application.Campaign.Models;
using itwazzup.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace itwazzup.Application.Campaign.Queries.GetCampaignResult
{
    /// <summary>
    /// Query
    /// </summary>
    [JsonSchema("GetCampaignResultQuery")]
    public class Query : IRequest<List<CampaignResultModel>>
    {
        public int CampaignId { get; set; }
    }

    /// <summary>
    /// Query Handler
    /// </summary>
    public class QueryHandler : IRequestHandler<Query, List<CampaignResultModel>>
    {
        private itwazzupDbContext itwazzupDbContext;

        public QueryHandler(itwazzupDbContext itwazzupDbContext)
        {
            this.itwazzupDbContext = itwazzupDbContext;
        }
        public async Task<List<CampaignResultModel>> Handle(Query request, CancellationToken cancellationToken)
        {
            var campaignItemList = await itwazzupDbContext
                                            .CampaignItems
                                            .Include(x => x.CampaignVotes)
                                            .Where(x => x.CampaignId == request.CampaignId)
                                            .ToListAsync();

            return campaignItemList.Select(x => new CampaignResultModel()
            {

                CampaignItemName = x.Name,
                TotalVotes = x.CampaignVotes.Count()
            }).OrderByDescending(x=> x.TotalVotes).ToList();
        }
    }
}