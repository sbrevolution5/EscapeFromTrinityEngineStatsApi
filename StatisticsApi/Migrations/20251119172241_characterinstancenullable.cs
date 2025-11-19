using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class characterinstancenullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ensure any invalid/placeholder character ids are cleared so the FK can be created
            migrationBuilder.Sql(@"
                UPDATE ""CardInstances"" ci
                SET ""CharacterId"" = NULL
                WHERE ""CharacterId"" IS NOT NULL
                  AND NOT EXISTS (
                    SELECT 1 FROM ""CharacterInstances"" ch WHERE ch.""Id"" = ci.""CharacterId""
                  );
            ");

            // Also clear CharacterId = 0 if you have placeholders
            migrationBuilder.Sql(@"
                UPDATE ""CardInstances""
                SET ""CharacterId"" = NULL
                WHERE ""CharacterId"" = 0;
            ");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CardInstances",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CardInstances",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
