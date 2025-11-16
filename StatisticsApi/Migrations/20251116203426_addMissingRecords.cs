using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class addMissingRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleRecord_BattleInstances_BattleInstanceId",
                table: "BattleRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleRecord_GameVersions_VersionId",
                table: "BattleRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CardRecords_CharacterRecord_CharacterRecordId",
                table: "CardRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterRecord_CharacterInstances_CharacterInstanceId",
                table: "CharacterRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterRecord_GameResults_GameResultId",
                table: "CharacterRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterRecord_GameVersions_VersionId",
                table: "CharacterRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomRecords_BattleRecord_BattleRecordId",
                table: "RoomRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterRecord",
                table: "CharacterRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleRecord",
                table: "BattleRecord");

            migrationBuilder.RenameTable(
                name: "CharacterRecord",
                newName: "CharacterRecords");

            migrationBuilder.RenameTable(
                name: "BattleRecord",
                newName: "BattleRecords");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterRecord_VersionId",
                table: "CharacterRecords",
                newName: "IX_CharacterRecords_VersionId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterRecord_GameResultId",
                table: "CharacterRecords",
                newName: "IX_CharacterRecords_GameResultId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterRecord_CharacterInstanceId",
                table: "CharacterRecords",
                newName: "IX_CharacterRecords_CharacterInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleRecord_VersionId",
                table: "BattleRecords",
                newName: "IX_BattleRecords_VersionId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleRecord_BattleInstanceId",
                table: "BattleRecords",
                newName: "IX_BattleRecords_BattleInstanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterRecords",
                table: "CharacterRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleRecords",
                table: "BattleRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleRecords_BattleInstances_BattleInstanceId",
                table: "BattleRecords",
                column: "BattleInstanceId",
                principalTable: "BattleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleRecords_GameVersions_VersionId",
                table: "BattleRecords",
                column: "VersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardRecords_CharacterRecords_CharacterRecordId",
                table: "CardRecords",
                column: "CharacterRecordId",
                principalTable: "CharacterRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterRecords_CharacterInstances_CharacterInstanceId",
                table: "CharacterRecords",
                column: "CharacterInstanceId",
                principalTable: "CharacterInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterRecords_GameResults_GameResultId",
                table: "CharacterRecords",
                column: "GameResultId",
                principalTable: "GameResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterRecords_GameVersions_VersionId",
                table: "CharacterRecords",
                column: "VersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomRecords_BattleRecords_BattleRecordId",
                table: "RoomRecords",
                column: "BattleRecordId",
                principalTable: "BattleRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleRecords_BattleInstances_BattleInstanceId",
                table: "BattleRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleRecords_GameVersions_VersionId",
                table: "BattleRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CardRecords_CharacterRecords_CharacterRecordId",
                table: "CardRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterRecords_CharacterInstances_CharacterInstanceId",
                table: "CharacterRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterRecords_GameResults_GameResultId",
                table: "CharacterRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterRecords_GameVersions_VersionId",
                table: "CharacterRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomRecords_BattleRecords_BattleRecordId",
                table: "RoomRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterRecords",
                table: "CharacterRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleRecords",
                table: "BattleRecords");

            migrationBuilder.RenameTable(
                name: "CharacterRecords",
                newName: "CharacterRecord");

            migrationBuilder.RenameTable(
                name: "BattleRecords",
                newName: "BattleRecord");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterRecords_VersionId",
                table: "CharacterRecord",
                newName: "IX_CharacterRecord_VersionId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterRecords_GameResultId",
                table: "CharacterRecord",
                newName: "IX_CharacterRecord_GameResultId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterRecords_CharacterInstanceId",
                table: "CharacterRecord",
                newName: "IX_CharacterRecord_CharacterInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleRecords_VersionId",
                table: "BattleRecord",
                newName: "IX_BattleRecord_VersionId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleRecords_BattleInstanceId",
                table: "BattleRecord",
                newName: "IX_BattleRecord_BattleInstanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterRecord",
                table: "CharacterRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleRecord",
                table: "BattleRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleRecord_BattleInstances_BattleInstanceId",
                table: "BattleRecord",
                column: "BattleInstanceId",
                principalTable: "BattleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleRecord_GameVersions_VersionId",
                table: "BattleRecord",
                column: "VersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardRecords_CharacterRecord_CharacterRecordId",
                table: "CardRecords",
                column: "CharacterRecordId",
                principalTable: "CharacterRecord",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterRecord_CharacterInstances_CharacterInstanceId",
                table: "CharacterRecord",
                column: "CharacterInstanceId",
                principalTable: "CharacterInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterRecord_GameResults_GameResultId",
                table: "CharacterRecord",
                column: "GameResultId",
                principalTable: "GameResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterRecord_GameVersions_VersionId",
                table: "CharacterRecord",
                column: "VersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomRecords_BattleRecord_BattleRecordId",
                table: "RoomRecords",
                column: "BattleRecordId",
                principalTable: "BattleRecord",
                principalColumn: "Id");
        }
    }
}
