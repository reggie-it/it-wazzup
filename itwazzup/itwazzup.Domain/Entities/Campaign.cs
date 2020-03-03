using System;
using System.Collections.Generic;
using System.Text;

namespace itwazzup.Domain.Entities
{
    public class Campaign : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public int MaxVotes { get; set; }
        public bool Closed { get; set; }
        public List<CampaignItem> CampaignItems { get; set; }
    }
}
