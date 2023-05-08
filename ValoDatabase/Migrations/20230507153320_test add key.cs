using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValoDatabase.Migrations
{
    /// <inheritdoc />
    public partial class testaddkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_AgentID",
                table: "PlayerStat",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_MatchID",
                table: "PlayerStat",
                column: "MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_PlayerID",
                table: "PlayerStat",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStat_Agent_AgentID",
                table: "PlayerStat",
                column: "AgentID",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStat_Match_MatchID",
                table: "PlayerStat",
                column: "MatchID",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStat_Player_PlayerID",
                table: "PlayerStat",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStat_Agent_AgentID",
                table: "PlayerStat");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStat_Match_MatchID",
                table: "PlayerStat");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStat_Player_PlayerID",
                table: "PlayerStat");

            migrationBuilder.DropIndex(
                name: "IX_PlayerStat_AgentID",
                table: "PlayerStat");

            migrationBuilder.DropIndex(
                name: "IX_PlayerStat_MatchID",
                table: "PlayerStat");

            migrationBuilder.DropIndex(
                name: "IX_PlayerStat_PlayerID",
                table: "PlayerStat");
        }
    }
}
