using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.Annotations;
using MediatR;
using itwazzup.Persistence.Context;
using itwazzup.Application.CampaignItem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace itwazzup.Application.CampaignItem.Queries.GetCampaignItemList
{
    /// <summary>
    /// Query
    /// </summary>
    [JsonSchema("GetCampaignItemListQuery")]
    public class Query : IRequest<List<CampaignItemModel>>
    {
        public int CampaignId { get; set; }
    }

    /// <summary>
    /// Query Handler
    /// </summary>
    public class QueryHandler : IRequestHandler<Query, List<CampaignItemModel>>
    {
        private readonly itwazzupDbContext dbContext;

        public QueryHandler(itwazzupDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<CampaignItemModel>> Handle(Query request, CancellationToken cancellationToken)
        {
            Func<Domain.Entities.CampaignItem, CampaignItemModel> ToCampaignItemModel = x => new CampaignItemModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            };

            return (await dbContext.CampaignItems
                .Where(x => x.Campaign.Id == request.CampaignId)
                .ToListAsync()).Select(ToCampaignItemModel).ToList();
        }
    }
}