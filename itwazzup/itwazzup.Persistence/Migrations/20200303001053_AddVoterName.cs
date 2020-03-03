using Microsoft.EntityFrameworkCore.Migrations;

namespace itwazzup.Persistence.Migrations
{
    public partial class AddVoterName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VoterName",
                table: "CampaignVotes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoterName",
                table: "CampaignVotes");
        }
    }
}
