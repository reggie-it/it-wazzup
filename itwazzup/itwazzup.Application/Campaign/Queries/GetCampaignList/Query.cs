using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.Annotations;
using MediatR;
using itwazzup.Persistence.Context;
using itwazzup.Application.Campaign.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace itwazzup.Application.Campaign.Queries.GetCampaignList
{
    /// <summary>
    /// Query
    /// </summary>
    [JsonSchema("GetCampaignListQuery")]
    public class Query : IRequest<List<CampaignModel>>
    {
        public bool? IsClosed { get; set; }
    }

    /// <summary>
    /// Query Handler
    /// </summary>
    public class QueryHandler : IRequestHandler<Query, List<CampaignModel>>
    {
        private readonly itwazzupDbContext dbContext;

        public QueryHandler(itwazzupDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<CampaignModel>> Handle(Query request, CancellationToken cancellationToken)
        {
            Func<Domain.Entities.Campaign, CampaignModel> ToCampaignModel = x => new CampaignModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Closed = x.Closed,
                CreatedBy = x.CreatedBy,
                MaxVotes = x.MaxVotes
            };

            if (!request.IsClosed.HasValue)
            {
                return (await dbContext.Campaigns.ToListAsync())
              .Select(ToCampaignModel).ToList();
            }

            return (await dbContext.Campaigns
                .Where(x => x.Closed == request.IsClosed)
                .ToListAsync()).Select(ToCampaignModel).ToList();
        }
    }
}