using System;

namespace itwazzup.Application.CampaignItem.Models
{
    public class CampaignItemModel
    {
        public CampaignItemModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxStars { get; set; } = 2; // Hard-coded to 2 for mocking purposes
    }
}