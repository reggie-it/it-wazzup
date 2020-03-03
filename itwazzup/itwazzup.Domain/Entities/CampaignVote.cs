using System;

namespace itwazzup.Domain.Entities
{
    public class CampaignVote : BaseEntity
    {
        public int CampaignId { get; set; }

        public Campaign Campaign { get; set; }

        public CampaignItem CampaignItem { get; set; }

        public int CampaignItemId { get; set; }

        public int VoterId { get; set; }

        public string VoterName { get; set; }

        public DateTime ReferenceDate { get; set; }
    }


}
