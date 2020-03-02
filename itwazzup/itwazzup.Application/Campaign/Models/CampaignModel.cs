using System;

namespace itwazzup.Application.Campaign.Models
{
    public class CampaignModel
    {
        public CampaignModel()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public int MaxVotes { get; set; }
        public bool Closed { get; set; }
    }
}