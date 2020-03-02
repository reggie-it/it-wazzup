using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.Annotations;
using MediatR;
using itwazzup.Persistence.Context;
using itwazzup.Application.Campaign.Models;

namespace itwazzup.Application.Campaign.Commands.Create
{
    /// <summary>
    /// Command
    /// </summary>
    [JsonSchema("CreateCommand")]
    public class Command : IRequest<Response>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public int MaxVotes { get; set; }
        public bool Closed { get; set; }
    }

    /// <summary>
    /// Command Handler
    /// </summary>
    public class CommandHandler : IRequestHandler<Command, Response>
    {
        private readonly itwazzupDbContext dbContext;

        public CommandHandler(itwazzupDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var newCampaign = new Domain.Entities.Campaign()
            {
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Closed = request.Closed,
                CreatedBy = request.CreatedBy,
                MaxVotes = request.MaxVotes
            };
            dbContext.Campaigns.Add(newCampaign);

            await dbContext.SaveChangesAsync();

            return new SuccessResponse<CampaignModel>(new CampaignModel()
            {
                Id = newCampaign.Id,
                Name = newCampaign.Name,
                Description = newCampaign.Description,
                StartDate = newCampaign.StartDate,
                EndDate = newCampaign.EndDate,
                Closed = newCampaign.Closed,
                CreatedBy = newCampaign.CreatedBy,
                MaxVotes = newCampaign.MaxVotes
            });
        }
    }
}