using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWithService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopAffordablePassives_PassiveRecords_PassiveRecordId",
                table: "ShopAffordablePassives");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopPurchasedPassives_PassiveRecords_PassiveRecordId",
                table: "ShopPurchasedPassives");

            migrationBuilder.RenameColumn(
                name: "PassiveRecordId",
                table: "ShopPurchasedPassives",
                newName: "PassiveInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopPurchasedPassives_PassiveRecordId",
                table: "ShopPurchasedPassives",
                newName: "IX_ShopPurchasedPassives_PassiveInstanceId");

            migrationBuilder.RenameColumn(
                name: "PassiveRecordId",
                table: "ShopAffordablePassives",
                newName: "PassiveInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopAffordablePassives_PassiveRecordId",
                table: "ShopAffordablePassives",
                newName: "IX_ShopAffordablePassives_PassiveInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopAffordablePassives_PassiveInstances_PassiveInstanceId",
                table: "ShopAffordablePassives",
                column: "PassiveInstanceId",
                principalTable: "PassiveInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopPurchasedPassives_PassiveInstances_PassiveInstanceId",
                table: "ShopPurchasedPassives",
                column: "PassiveInstanceId",
                principalTable: "PassiveInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopAffordablePassives_PassiveInstances_PassiveInstanceId",
                table: "ShopAffordablePassives");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopPurchasedPassives_PassiveInstances_PassiveInstanceId",
                table: "ShopPurchasedPassives");

            migrationBuilder.RenameColumn(
                name: "PassiveInstanceId",
                table: "ShopPurchasedPassives",
                newName: "PassiveRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopPurchasedPassives_PassiveInstanceId",
                table: "ShopPurchasedPassives",
                newName: "IX_ShopPurchasedPassives_PassiveRecordId");

            migrationBuilder.RenameColumn(
                name: "PassiveInstanceId",
                table: "ShopAffordablePassives",
                newName: "PassiveRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopAffordablePassives_PassiveInstanceId",
                table: "ShopAffordablePassives",
                newName: "IX_ShopAffordablePassives_PassiveRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopAffordablePassives_PassiveRecords_PassiveRecordId",
                table: "ShopAffordablePassives",
                column: "PassiveRecordId",
                principalTable: "PassiveRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopPurchasedPassives_PassiveRecords_PassiveRecordId",
                table: "ShopPurchasedPassives",
                column: "PassiveRecordId",
                principalTable: "PassiveRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
