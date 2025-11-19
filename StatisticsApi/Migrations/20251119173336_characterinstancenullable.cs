using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    public partial class characterinstancenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing FK constraint if it exists
            migrationBuilder.Sql(@"
                ALTER TABLE ""CardInstances""
                DROP CONSTRAINT IF EXISTS ""FK_CardInstances_CharacterInstances_CharacterId"" CASCADE;
            ");

            // Ensure any invalid/placeholder character ids are cleared
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

            // Make the column nullable
            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CardInstances",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            // Recreate the FK constraint with ON DELETE SET NULL
            migrationBuilder.Sql(@"
                ALTER TABLE ""CardInstances""
                ADD CONSTRAINT ""FK_CardInstances_CharacterInstances_CharacterId""
                FOREIGN KEY (""CharacterId"")
                REFERENCES ""CharacterInstances"" (""Id"")
                ON DELETE SET NULL;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE ""CardInstances""
                DROP CONSTRAINT IF EXISTS ""FK_CardInstances_CharacterInstances_CharacterId"";
            ");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CardInstances",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.Sql(@"
                ALTER TABLE ""CardInstances""
                ADD CONSTRAINT ""FK_CardInstances_CharacterInstances_CharacterId""
                FOREIGN KEY (""CharacterId"")
                REFERENCES ""CharacterInstances"" (""Id"")
                ON DELETE CASCADE;
            ");
        }
    }
}
