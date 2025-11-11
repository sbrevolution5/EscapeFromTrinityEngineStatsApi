using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class correctionOfDbContextAddVersioning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceCards_CardChoiceRecord_CardChoiceRecordId",
                table: "CardChoiceCards");

            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceRecord_CardInstances_CardPickedId",
                table: "CardChoiceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceRecord_RewardRecords_RewardRecordId",
                table: "CardChoiceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_RerolledCardCardInstances_CardChoiceRecord_CardChoiceRecord~",
                table: "RerolledCardCardInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardChoiceRecord",
                table: "CardChoiceRecord");

            migrationBuilder.RenameTable(
                name: "CardChoiceRecord",
                newName: "CardChoiceRecords");

            migrationBuilder.RenameIndex(
                name: "IX_CardChoiceRecord_RewardRecordId",
                table: "CardChoiceRecords",
                newName: "IX_CardChoiceRecords_RewardRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_CardChoiceRecord_CardPickedId",
                table: "CardChoiceRecords",
                newName: "IX_CardChoiceRecords_CardPickedId");

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "ShopRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "RewardRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "EventRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "CharacterRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "CardChoiceRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardChoiceRecords",
                table: "CardChoiceRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShopRecords_VersionId",
                table: "ShopRecords",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardRecords_VersionId",
                table: "RewardRecords",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRecords_VersionId",
                table: "EventRecords",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRecord_VersionId",
                table: "CharacterRecord",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleRecord_VersionId",
                table: "BattleRecord",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CardChoiceRecords_VersionId",
                table: "CardChoiceRecords",
                column: "VersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleRecord_GameVersions_VersionId",
                table: "BattleRecord",
                column: "VersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardChoiceCards_CardChoiceRecords_CardChoiceRecordId",
                table: "CardChoiceCards",
                column: "CardChoiceRecordId",
                principalTable: "CardChoiceRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardChoiceRecords_CardInstances_CardPickedId",
                table: "CardChoiceRecords",
                column: "CardPickedId",
                principalTable: "CardInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardChoiceRecords_GameVersions_VersionId",
                table: "CardChoiceRecords",
                column: "VersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardChoiceRecords_RewardRecords_RewardRecordId",
                table: "CardChoiceRecords",
                column: "RewardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterRecord_GameVersions_VersionId",
                table: "CharacterRecord",
                column: "VersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRecords_GameVersions_VersionId",
                table: "EventRecords",
                column: "VersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RerolledCardCardInstances_CardChoiceRecords_CardChoiceRecor~",
                table: "RerolledCardCardInstances",
                column: "CardChoiceRecordId",
                principalTable: "CardChoiceRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardRecords_GameVersions_VersionId",
                table: "RewardRecords",
                column: "VersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopRecords_GameVersions_VersionId",
                table: "ShopRecords",
                column: "VersionId",
                principalTable: "GameVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleRecord_GameVersions_VersionId",
                table: "BattleRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceCards_CardChoiceRecords_CardChoiceRecordId",
                table: "CardChoiceCards");

            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceRecords_CardInstances_CardPickedId",
                table: "CardChoiceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceRecords_GameVersions_VersionId",
                table: "CardChoiceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceRecords_RewardRecords_RewardRecordId",
                table: "CardChoiceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterRecord_GameVersions_VersionId",
                table: "CharacterRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRecords_GameVersions_VersionId",
                table: "EventRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_RerolledCardCardInstances_CardChoiceRecords_CardChoiceRecor~",
                table: "RerolledCardCardInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardRecords_GameVersions_VersionId",
                table: "RewardRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopRecords_GameVersions_VersionId",
                table: "ShopRecords");

            migrationBuilder.DropIndex(
                name: "IX_ShopRecords_VersionId",
                table: "ShopRecords");

            migrationBuilder.DropIndex(
                name: "IX_RewardRecords_VersionId",
                table: "RewardRecords");

            migrationBuilder.DropIndex(
                name: "IX_EventRecords_VersionId",
                table: "EventRecords");

            migrationBuilder.DropIndex(
                name: "IX_CharacterRecord_VersionId",
                table: "CharacterRecord");

            migrationBuilder.DropIndex(
                name: "IX_BattleRecord_VersionId",
                table: "BattleRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardChoiceRecords",
                table: "CardChoiceRecords");

            migrationBuilder.DropIndex(
                name: "IX_CardChoiceRecords_VersionId",
                table: "CardChoiceRecords");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "ShopRecords");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "RewardRecords");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "EventRecords");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "CharacterRecord");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "CardChoiceRecords");

            migrationBuilder.RenameTable(
                name: "CardChoiceRecords",
                newName: "CardChoiceRecord");

            migrationBuilder.RenameIndex(
                name: "IX_CardChoiceRecords_RewardRecordId",
                table: "CardChoiceRecord",
                newName: "IX_CardChoiceRecord_RewardRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_CardChoiceRecords_CardPickedId",
                table: "CardChoiceRecord",
                newName: "IX_CardChoiceRecord_CardPickedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardChoiceRecord",
                table: "CardChoiceRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardChoiceCards_CardChoiceRecord_CardChoiceRecordId",
                table: "CardChoiceCards",
                column: "CardChoiceRecordId",
                principalTable: "CardChoiceRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardChoiceRecord_CardInstances_CardPickedId",
                table: "CardChoiceRecord",
                column: "CardPickedId",
                principalTable: "CardInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardChoiceRecord_RewardRecords_RewardRecordId",
                table: "CardChoiceRecord",
                column: "RewardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RerolledCardCardInstances_CardChoiceRecord_CardChoiceRecord~",
                table: "RerolledCardCardInstances",
                column: "CardChoiceRecordId",
                principalTable: "CardChoiceRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
