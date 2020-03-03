namespace itwazzup.Domain.Entities
{
    public class CampaignItem : BaseEntity
    {

        public int CampaignId { get; set; }

        public Campaign Campaign { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }


}
