using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class battlewinstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WonBattle",
                table: "BattleRecords",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WonBattle",
                table: "BattleRecords");
        }
    }
}
