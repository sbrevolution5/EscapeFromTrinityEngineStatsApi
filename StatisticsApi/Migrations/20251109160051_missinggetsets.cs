using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class missinggetsets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UpgradePurchased",
                table: "ShopRecords",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpgradedCardId",
                table: "ShopRecords",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoldGained",
                table: "RewardRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartySlot",
                table: "PassiveRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GameVersion",
                table: "GameResults",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LevelsCompleted",
                table: "GameResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "GameResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RemainingGold",
                table: "GameResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RemainingTeamwork",
                table: "GameResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomsCompleted",
                table: "GameResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RunPerk",
                table: "GameResults",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalGoldEarned",
                table: "GameResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalTeamworkEarned",
                table: "GameResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Win",
                table: "GameResults",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ChoiceSelected",
                table: "EventRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamworkOnEnter",
                table: "EventRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartySlot",
                table: "CardRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DuplicatePicked",
                table: "CardChoiceRecord",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "CardChoiceRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelNumber",
                table: "CardChoiceRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RerollCount",
                table: "CardChoiceRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamworkSpent",
                table: "CardChoiceRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "UpgradePicked",
                table: "CardChoiceRecord",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Character1CardsPlayed",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Character1DamageDealt",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Character1Downed",
                table: "BattleRecord",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Character1HpEnd",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Character1HpStart",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Character2CardsPlayed",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Character2DamageDealt",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Character2Downed",
                table: "BattleRecord",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Character2HpEnd",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Character2HpStart",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Character3CardsPlayed",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Character3DamageDealt",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Character3Downed",
                table: "BattleRecord",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Character3HpEnd",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Character3HpStart",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharacterResting",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FloorEncountered",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoldGained",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelEncountered",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoundsElapsed",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamworkEnd",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamworkStart",
                table: "BattleRecord",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopRecords_UpgradedCardId",
                table: "ShopRecords",
                column: "UpgradedCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopRecords_CardRecords_UpgradedCardId",
                table: "ShopRecords",
                column: "UpgradedCardId",
                principalTable: "CardRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopRecords_CardRecords_UpgradedCardId",
                table: "ShopRecords");

            migrationBuilder.DropIndex(
                name: "IX_ShopRecords_UpgradedCardId",
                table: "ShopRecords");

            migrationBuilder.DropColumn(
                name: "UpgradePurchased",
                table: "ShopRecords");

            migrationBuilder.DropColumn(
                name: "UpgradedCardId",
                table: "ShopRecords");

            migrationBuilder.DropColumn(
                name: "GoldGained",
                table: "RewardRecords");

            migrationBuilder.DropColumn(
                name: "PartySlot",
                table: "PassiveRecords");

            migrationBuilder.DropColumn(
                name: "GameVersion",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "LevelsCompleted",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "RemainingGold",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "RemainingTeamwork",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "RoomsCompleted",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "RunPerk",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "TotalGoldEarned",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "TotalTeamworkEarned",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "Win",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "ChoiceSelected",
                table: "EventRecords");

            migrationBuilder.DropColumn(
                name: "TeamworkOnEnter",
                table: "EventRecords");

            migrationBuilder.DropColumn(
                name: "PartySlot",
                table: "CardRecords");

            migrationBuilder.DropColumn(
                name: "DuplicatePicked",
                table: "CardChoiceRecord");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "CardChoiceRecord");

            migrationBuilder.DropColumn(
                name: "LevelNumber",
                table: "CardChoiceRecord");

            migrationBuilder.DropColumn(
                name: "RerollCount",
                table: "CardChoiceRecord");

            migrationBuilder.DropColumn(
                name: "TeamworkSpent",
                table: "CardChoiceRecord");

            migrationBuilder.DropColumn(
                name: "UpgradePicked",
                table: "CardChoiceRecord");

            migrationBuilder.DropColumn(
                name: "Character1CardsPlayed",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character1DamageDealt",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character1Downed",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character1HpEnd",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character1HpStart",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character2CardsPlayed",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character2DamageDealt",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character2Downed",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character2HpEnd",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character2HpStart",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character3CardsPlayed",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character3DamageDealt",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character3Downed",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character3HpEnd",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "Character3HpStart",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "CharacterResting",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "FloorEncountered",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "GoldGained",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "LevelEncountered",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "RoundsElapsed",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "TeamworkEnd",
                table: "BattleRecord");

            migrationBuilder.DropColumn(
                name: "TeamworkStart",
                table: "BattleRecord");
        }
    }
}
