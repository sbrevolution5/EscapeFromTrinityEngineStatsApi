using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class AddInstances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleRecord_BattleInstance_BattleInstanceId",
                table: "BattleRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceCards_CardInstance_CardInstanceId",
                table: "CardChoiceCards");

            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceRecord_CardInstance_CardPickedId",
                table: "CardChoiceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CardRecords_CardInstance_CardInstanceId",
                table: "CardRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_EventChoiceInstance_EventInstance_EventId",
                table: "EventChoiceInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRecords_EventInstance_EventInstanceId",
                table: "EventRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_PassiveRecords_PassiveInstance_PassiveInstanceId",
                table: "PassiveRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_RerolledCardCardInstances_CardInstance_CardInstanceId",
                table: "RerolledCardCardInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopAffordableCards_CardInstance_CardInstanceId",
                table: "ShopAffordableCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopPurchasedCards_CardInstance_CardInstanceId",
                table: "ShopPurchasedCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassiveInstance",
                table: "PassiveInstance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventInstance",
                table: "EventInstance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardInstance",
                table: "CardInstance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleInstance",
                table: "BattleInstance");

            migrationBuilder.RenameTable(
                name: "PassiveInstance",
                newName: "PassiveInstances");

            migrationBuilder.RenameTable(
                name: "EventInstance",
                newName: "EventInstances");

            migrationBuilder.RenameTable(
                name: "CardInstance",
                newName: "CardInstances");

            migrationBuilder.RenameTable(
                name: "BattleInstance",
                newName: "BattleInstances");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassiveInstances",
                table: "PassiveInstances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventInstances",
                table: "EventInstances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardInstances",
                table: "CardInstances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleInstances",
                table: "BattleInstances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleRecord_BattleInstances_BattleInstanceId",
                table: "BattleRecord",
                column: "BattleInstanceId",
                principalTable: "BattleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardChoiceCards_CardInstances_CardInstanceId",
                table: "CardChoiceCards",
                column: "CardInstanceId",
                principalTable: "CardInstances",
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
                name: "FK_CardRecords_CardInstances_CardInstanceId",
                table: "CardRecords",
                column: "CardInstanceId",
                principalTable: "CardInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventChoiceInstance_EventInstances_EventId",
                table: "EventChoiceInstance",
                column: "EventId",
                principalTable: "EventInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRecords_EventInstances_EventInstanceId",
                table: "EventRecords",
                column: "EventInstanceId",
                principalTable: "EventInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassiveRecords_PassiveInstances_PassiveInstanceId",
                table: "PassiveRecords",
                column: "PassiveInstanceId",
                principalTable: "PassiveInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RerolledCardCardInstances_CardInstances_CardInstanceId",
                table: "RerolledCardCardInstances",
                column: "CardInstanceId",
                principalTable: "CardInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopAffordableCards_CardInstances_CardInstanceId",
                table: "ShopAffordableCards",
                column: "CardInstanceId",
                principalTable: "CardInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopPurchasedCards_CardInstances_CardInstanceId",
                table: "ShopPurchasedCards",
                column: "CardInstanceId",
                principalTable: "CardInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleRecord_BattleInstances_BattleInstanceId",
                table: "BattleRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceCards_CardInstances_CardInstanceId",
                table: "CardChoiceCards");

            migrationBuilder.DropForeignKey(
                name: "FK_CardChoiceRecord_CardInstances_CardPickedId",
                table: "CardChoiceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CardRecords_CardInstances_CardInstanceId",
                table: "CardRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_EventChoiceInstance_EventInstances_EventId",
                table: "EventChoiceInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRecords_EventInstances_EventInstanceId",
                table: "EventRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_PassiveRecords_PassiveInstances_PassiveInstanceId",
                table: "PassiveRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_RerolledCardCardInstances_CardInstances_CardInstanceId",
                table: "RerolledCardCardInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopAffordableCards_CardInstances_CardInstanceId",
                table: "ShopAffordableCards");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopPurchasedCards_CardInstances_CardInstanceId",
                table: "ShopPurchasedCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassiveInstances",
                table: "PassiveInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventInstances",
                table: "EventInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardInstances",
                table: "CardInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleInstances",
                table: "BattleInstances");

            migrationBuilder.RenameTable(
                name: "PassiveInstances",
                newName: "PassiveInstance");

            migrationBuilder.RenameTable(
                name: "EventInstances",
                newName: "EventInstance");

            migrationBuilder.RenameTable(
                name: "CardInstances",
                newName: "CardInstance");

            migrationBuilder.RenameTable(
                name: "BattleInstances",
                newName: "BattleInstance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassiveInstance",
                table: "PassiveInstance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventInstance",
                table: "EventInstance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardInstance",
                table: "CardInstance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleInstance",
                table: "BattleInstance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleRecord_BattleInstance_BattleInstanceId",
                table: "BattleRecord",
                column: "BattleInstanceId",
                principalTable: "BattleInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardChoiceCards_CardInstance_CardInstanceId",
                table: "CardChoiceCards",
                column: "CardInstanceId",
                principalTable: "CardInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardChoiceRecord_CardInstance_CardPickedId",
                table: "CardChoiceRecord",
                column: "CardPickedId",
                principalTable: "CardInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardRecords_CardInstance_CardInstanceId",
                table: "CardRecords",
                column: "CardInstanceId",
                principalTable: "CardInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventChoiceInstance_EventInstance_EventId",
                table: "EventChoiceInstance",
                column: "EventId",
                principalTable: "EventInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRecords_EventInstance_EventInstanceId",
                table: "EventRecords",
                column: "EventInstanceId",
                principalTable: "EventInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassiveRecords_PassiveInstance_PassiveInstanceId",
                table: "PassiveRecords",
                column: "PassiveInstanceId",
                principalTable: "PassiveInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RerolledCardCardInstances_CardInstance_CardInstanceId",
                table: "RerolledCardCardInstances",
                column: "CardInstanceId",
                principalTable: "CardInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopAffordableCards_CardInstance_CardInstanceId",
                table: "ShopAffordableCards",
                column: "CardInstanceId",
                principalTable: "CardInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopPurchasedCards_CardInstance_CardInstanceId",
                table: "ShopPurchasedCards",
                column: "CardInstanceId",
                principalTable: "CardInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
