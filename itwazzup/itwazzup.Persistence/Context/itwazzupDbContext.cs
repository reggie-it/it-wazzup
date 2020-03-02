using itwazzup.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace itwazzup.Persistence.Context
{
    public class itwazzupDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public itwazzupDbContext(DbContextOptions<itwazzupDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<CampaignItem> CampaignItems { get; set; }

        public DbSet<CampaignVote> CampaignVotes { get; set; }
    }
}

