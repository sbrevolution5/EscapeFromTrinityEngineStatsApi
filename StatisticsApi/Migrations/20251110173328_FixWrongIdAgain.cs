using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class FixWrongIdAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RerolledCardCardInstances_CardChoiceRecord_CardInstanceId",
                table: "RerolledCardCardInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardGivenTradeCards_RewardRecords_CardRecordId",
                table: "RewardGivenTradeCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardJunkCards_RewardRecords_CardRecordId",
                table: "RewardJunkCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardRecievedTradeCards_RewardRecords_CardRecordId",
                table: "RewardRecievedTradeCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardRemovedCards_RewardRecords_CardRecordId",
                table: "RewardRemovedCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardUpgradedCards_RewardRecords_CardRecordId",
                table: "RewardUpgradedCards");

            migrationBuilder.AddForeignKey(
                name: "FK_RerolledCardCardInstances_CardChoiceRecord_CardChoiceRecord~",
                table: "RerolledCardCardInstances",
                column: "CardChoiceRecordId",
                principalTable: "CardChoiceRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardGivenTradeCards_RewardRecords_RewardRecordId",
                table: "RewardGivenTradeCards",
                column: "RewardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardJunkCards_RewardRecords_RewardRecordId",
                table: "RewardJunkCards",
                column: "RewardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardRecievedTradeCards_RewardRecords_RewardRecordId",
                table: "RewardRecievedTradeCards",
                column: "RewardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardRemovedCards_RewardRecords_RewardRecordId",
                table: "RewardRemovedCards",
                column: "RewardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardUpgradedCards_RewardRecords_RewardRecordId",
                table: "RewardUpgradedCards",
                column: "RewardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RerolledCardCardInstances_CardChoiceRecord_CardChoiceRecord~",
                table: "RerolledCardCardInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardGivenTradeCards_RewardRecords_RewardRecordId",
                table: "RewardGivenTradeCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardJunkCards_RewardRecords_RewardRecordId",
                table: "RewardJunkCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardRecievedTradeCards_RewardRecords_RewardRecordId",
                table: "RewardRecievedTradeCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardRemovedCards_RewardRecords_RewardRecordId",
                table: "RewardRemovedCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardUpgradedCards_RewardRecords_RewardRecordId",
                table: "RewardUpgradedCards");

            migrationBuilder.AddForeignKey(
                name: "FK_RerolledCardCardInstances_CardChoiceRecord_CardInstanceId",
                table: "RerolledCardCardInstances",
                column: "CardInstanceId",
                principalTable: "CardChoiceRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardGivenTradeCards_RewardRecords_CardRecordId",
                table: "RewardGivenTradeCards",
                column: "CardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardJunkCards_RewardRecords_CardRecordId",
                table: "RewardJunkCards",
                column: "CardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardRecievedTradeCards_RewardRecords_CardRecordId",
                table: "RewardRecievedTradeCards",
                column: "CardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardRemovedCards_RewardRecords_CardRecordId",
                table: "RewardRemovedCards",
                column: "CardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardUpgradedCards_RewardRecords_CardRecordId",
                table: "RewardUpgradedCards",
                column: "CardRecordId",
                principalTable: "RewardRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
