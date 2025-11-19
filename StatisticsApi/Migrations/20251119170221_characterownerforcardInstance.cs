using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class characterownerforcardInstance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "CardInstances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Junk",
                table: "CardInstances",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CardInstances_CharacterId",
                table: "CardInstances",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardInstances_CharacterInstances_CharacterId",
                table: "CardInstances",
                column: "CharacterId",
                principalTable: "CharacterInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardInstances_CharacterInstances_CharacterId",
                table: "CardInstances");

            migrationBuilder.DropIndex(
                name: "IX_CardInstances_CharacterId",
                table: "CardInstances");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "CardInstances");

            migrationBuilder.DropColumn(
                name: "Junk",
                table: "CardInstances");
        }
    }
}
