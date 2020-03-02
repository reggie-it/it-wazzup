using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace itwazzup.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    MaxVotes = table.Column<int>(nullable: false),
                    Closed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignItems_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignVotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(nullable: true),
                    CampaignItemId = table.Column<int>(nullable: true),
                    VoterId = table.Column<int>(nullable: false),
                    ReferenceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignVotes_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignVotes_CampaignItems_CampaignItemId",
                        column: x => x.CampaignItemId,
                        principalTable: "CampaignItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignItems_CampaignId",
                table: "CampaignItems",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignVotes_CampaignId",
                table: "CampaignVotes",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignVotes_CampaignItemId",
                table: "CampaignVotes",
                column: "CampaignItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignVotes");

            migrationBuilder.DropTable(
                name: "CampaignItems");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
