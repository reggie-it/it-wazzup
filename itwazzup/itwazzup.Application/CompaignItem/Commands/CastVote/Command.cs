using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.Annotations;
using MediatR;
using itwazzup.Persistence.Context;
using System.Linq;

namespace itwazzup.Application.CampaignItem.Commands.CastVote
{
    /// <summary>
    /// Command
    /// </summary>
    [JsonSchema("CastVoteCommand")]
    public class Command : IRequest<Response>
    {
        public string VoterName { get; set; }

        public int CampaignId { get; set; }

        public List<int> CampaignIdList { get; set; }
    }

    /// <summary>
    /// Command Handler
    /// </summary>
    public class CommandHandler : IRequestHandler<Command, Response>
    {
        private itwazzupDbContext dbContext;

        public CommandHandler(itwazzupDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            dbContext.CampaignVotes.AddRange(request.CampaignIdList?.Select(x => new Domain.Entities.CampaignVote()
            {
                CampaignId = request.CampaignId,
                CampaignItemId = x,
                VoterName = request.VoterName,
                ReferenceDate = DateTime.Now
            }));

            await dbContext.SaveChangesAsync();

            return new SuccessResponse("Vote casted");
        }
    }
}