using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class raritycards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rarity",
                table: "PassiveInstances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rarity",
                table: "CardInstances",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "PassiveInstances");

            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "CardInstances");
        }
    }
}
