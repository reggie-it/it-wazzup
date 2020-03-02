using System;

namespace itwazzup.Domain.Entities
{
    public class CampaignVote : BaseEntity
    {
        public Campaign Campaign { get; set; }

        public CampaignItem CampaignItem { get; set; }

        public int VoterId { get; set; }

        public DateTime ReferenceDate { get; set; }
    }


}
