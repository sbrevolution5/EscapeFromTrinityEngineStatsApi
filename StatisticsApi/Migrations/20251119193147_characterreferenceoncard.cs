using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class characterreferenceoncard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterInstanceId",
                table: "CardInstances",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardInstances_CharacterInstanceId",
                table: "CardInstances",
                column: "CharacterInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardInstances_CharacterInstances_CharacterInstanceId",
                table: "CardInstances",
                column: "CharacterInstanceId",
                principalTable: "CharacterInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardInstances_CharacterInstances_CharacterInstanceId",
                table: "CardInstances");

            migrationBuilder.DropIndex(
                name: "IX_CardInstances_CharacterInstanceId",
                table: "CardInstances");

            migrationBuilder.DropColumn(
                name: "CharacterInstanceId",
                table: "CardInstances");
        }
    }
}
