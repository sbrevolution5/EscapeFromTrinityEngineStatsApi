using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class GameVersionAsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameVersion",
                table: "GameResults");

            migrationBuilder.AddColumn<int>(
                name: "GameVersionId",
                table: "GameResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GameVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VersionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameVersions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_GameVersionId",
                table: "GameResults",
                column: "GameVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_GameVersions_GameVersionId",
                table: "GameResults",
                column: "GameVersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_GameVersions_GameVersionId",
                table: "GameResults");

            migrationBuilder.DropTable(
                name: "GameVersions");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_GameVersionId",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "GameVersionId",
                table: "GameResults");

            migrationBuilder.AddColumn<string>(
                name: "GameVersion",
                table: "GameResults",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
