namespace itwazzup.Domain.Entities
{
    public class CampaignItem : BaseEntity
    {
        public Campaign Campaign { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }


}
