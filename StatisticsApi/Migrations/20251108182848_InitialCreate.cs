using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StatisticsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BattleInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tier = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleInstance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInstance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterInstances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInstance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassiveInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassiveInstance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RewardRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GoldEntered = table.Column<int>(type: "integer", nullable: false),
                    GoldSpent = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BattleRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BattleInstanceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleRecord_BattleInstance_BattleInstanceId",
                        column: x => x.BattleInstanceId,
                        principalTable: "BattleInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventChoiceInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventChoiceInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventChoiceInstance_EventInstance_EventId",
                        column: x => x.EventId,
                        principalTable: "EventInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventInstanceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRecords_EventInstance_EventInstanceId",
                        column: x => x.EventInstanceId,
                        principalTable: "EventInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterInstanceId = table.Column<int>(type: "integer", nullable: false),
                    PartySlot = table.Column<int>(type: "integer", nullable: false),
                    GameResultId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterRecord_CharacterInstances_CharacterInstanceId",
                        column: x => x.CharacterInstanceId,
                        principalTable: "CharacterInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterRecord_GameResults_GameResultId",
                        column: x => x.GameResultId,
                        principalTable: "GameResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CardChoiceRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardPickedId = table.Column<int>(type: "integer", nullable: false),
                    RewardRecordId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardChoiceRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardChoiceRecord_CardInstance_CardPickedId",
                        column: x => x.CardPickedId,
                        principalTable: "CardInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardChoiceRecord_RewardRecords_RewardRecordId",
                        column: x => x.RewardRecordId,
                        principalTable: "RewardRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PassiveRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PassiveInstanceId = table.Column<int>(type: "integer", nullable: false),
                    GameResultId = table.Column<int>(type: "integer", nullable: true),
                    RewardRecordId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassiveRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassiveRecords_GameResults_GameResultId",
                        column: x => x.GameResultId,
                        principalTable: "GameResults",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PassiveRecords_PassiveInstance_PassiveInstanceId",
                        column: x => x.PassiveInstanceId,
                        principalTable: "PassiveInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassiveRecords_RewardRecords_RewardRecordId",
                        column: x => x.RewardRecordId,
                        principalTable: "RewardRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopAffordableCards",
                columns: table => new
                {
                    ShopRecordId = table.Column<int>(type: "integer", nullable: false),
                    CardInstanceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopAffordableCards", x => new { x.ShopRecordId, x.CardInstanceId });
                    table.ForeignKey(
                        name: "FK_ShopAffordableCards_CardInstance_CardInstanceId",
                        column: x => x.CardInstanceId,
                        principalTable: "CardInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopAffordableCards_ShopRecords_ShopRecordId",
                        column: x => x.ShopRecordId,
                        principalTable: "ShopRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopPurchasedCards",
                columns: table => new
                {
                    ShopRecordId = table.Column<int>(type: "integer", nullable: false),
                    CardInstanceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopPurchasedCards", x => new { x.ShopRecordId, x.CardInstanceId });
                    table.ForeignKey(
                        name: "FK_ShopPurchasedCards_CardInstance_CardInstanceId",
                        column: x => x.CardInstanceId,
                        principalTable: "CardInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopPurchasedCards_ShopRecords_ShopRecordId",
                        column: x => x.ShopRecordId,
                        principalTable: "ShopRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FloorNumber = table.Column<int>(type: "integer", nullable: false),
                    LevelNumber = table.Column<int>(type: "integer", nullable: false),
                    BattleRecordId = table.Column<int>(type: "integer", nullable: true),
                    EventRecordId = table.Column<int>(type: "integer", nullable: true),
                    ShopRecordId = table.Column<int>(type: "integer", nullable: true),
                    RewardRecordId = table.Column<int>(type: "integer", nullable: true),
                    GameResultId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomRecords_BattleRecord_BattleRecordId",
                        column: x => x.BattleRecordId,
                        principalTable: "BattleRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomRecords_EventRecords_EventRecordId",
                        column: x => x.EventRecordId,
                        principalTable: "EventRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomRecords_GameResults_GameResultId",
                        column: x => x.GameResultId,
                        principalTable: "GameResults",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomRecords_RewardRecords_RewardRecordId",
                        column: x => x.RewardRecordId,
                        principalTable: "RewardRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomRecords_ShopRecords_ShopRecordId",
                        column: x => x.ShopRecordId,
                        principalTable: "ShopRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CardRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardInstanceId = table.Column<int>(type: "integer", nullable: false),
                    CharacterRecordId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardRecords_CardInstance_CardInstanceId",
                        column: x => x.CardInstanceId,
                        principalTable: "CardInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardRecords_CharacterRecord_CharacterRecordId",
                        column: x => x.CharacterRecordId,
                        principalTable: "CharacterRecord",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CardChoiceCards",
                columns: table => new
                {
                    CardChoiceRecordId = table.Column<int>(type: "integer", nullable: false),
                    CardInstanceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardChoiceCards", x => new { x.CardChoiceRecordId, x.CardInstanceId });
                    table.ForeignKey(
                        name: "FK_CardChoiceCards_CardChoiceRecord_CardInstanceId",
                        column: x => x.CardInstanceId,
                        principalTable: "CardChoiceRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardChoiceCards_CardInstance_CardInstanceId",
                        column: x => x.CardInstanceId,
                        principalTable: "CardInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RerolledCardCardInstances",
                columns: table => new
                {
                    CardChoiceRecordId = table.Column<int>(type: "integer", nullable: false),
                    CardInstanceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RerolledCardCardInstances", x => new { x.CardChoiceRecordId, x.CardInstanceId });
                    table.ForeignKey(
                        name: "FK_RerolledCardCardInstances_CardChoiceRecord_CardInstanceId",
                        column: x => x.CardInstanceId,
                        principalTable: "CardChoiceRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RerolledCardCardInstances_CardInstance_CardInstanceId",
                        column: x => x.CardInstanceId,
                        principalTable: "CardInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopAffordablePassives",
                columns: table => new
                {
                    ShopRecordId = table.Column<int>(type: "integer", nullable: false),
                    PassiveRecordId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopAffordablePassives", x => new { x.ShopRecordId, x.PassiveRecordId });
                    table.ForeignKey(
                        name: "FK_ShopAffordablePassives_PassiveRecords_PassiveRecordId",
                        column: x => x.PassiveRecordId,
                        principalTable: "PassiveRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopAffordablePassives_ShopRecords_ShopRecordId",
                        column: x => x.ShopRecordId,
                        principalTable: "ShopRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopPurchasedPassives",
                columns: table => new
                {
                    ShopRecordId = table.Column<int>(type: "integer", nullable: false),
                    PassiveRecordId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopPurchasedPassives", x => new { x.ShopRecordId, x.PassiveRecordId });
                    table.ForeignKey(
                        name: "FK_ShopPurchasedPassives_PassiveRecords_PassiveRecordId",
                        column: x => x.PassiveRecordId,
                        principalTable: "PassiveRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopPurchasedPassives_ShopRecords_ShopRecordId",
                        column: x => x.ShopRecordId,
                        principalTable: "ShopRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RewardGivenTradeCards",
                columns: table => new
                {
                    RewardRecordId = table.Column<int>(type: "integer", nullable: false),
                    CardRecordId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardGivenTradeCards", x => new { x.RewardRecordId, x.CardRecordId });
                    table.ForeignKey(
                        name: "FK_RewardGivenTradeCards_CardRecords_CardRecordId",
                        column: x => x.CardRecordId,
                        principalTable: "CardRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RewardGivenTradeCards_RewardRecords_CardRecordId",
                        column: x => x.CardRecordId,
                        principalTable: "RewardRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RewardJunkCards",
                columns: table => new
                {
                    RewardRecordId = table.Column<int>(type: "integer", nullable: false),
                    CardRecordId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardJunkCards", x => new { x.RewardRecordId, x.CardRecordId });
                    table.ForeignKey(
                        name: "FK_RewardJunkCards_CardRecords_CardRecordId",
                        column: x => x.CardRecordId,
                        principalTable: "CardRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RewardJunkCards_RewardRecords_CardRecordId",
                        column: x => x.CardRecordId,
                        principalTable: "RewardRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RewardRecievedTradeCards",
                columns: table => new
                {
                    RewardRecordId = table.Column<int>(type: "integer", nullable: false),
                    CardRecordId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardRecievedTradeCards", x => new { x.RewardRecordId, x.CardRecordId });
                    table.ForeignKey(
                        name: "FK_RewardRecievedTradeCards_CardRecords_CardRecordId",
                        column: x => x.CardRecordId,
                        principalTable: "CardRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RewardRecievedTradeCards_RewardRecords_CardRecordId",
                        column: x => x.CardRecordId,
                        principalTable: "RewardRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RewardRemovedCards",
                columns: table => new
                {
                    RewardRecordId = table.Column<int>(type: "integer", nullable: false),
                    CardRecordId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardRemovedCards", x => new { x.RewardRecordId, x.CardRecordId });
                    table.ForeignKey(
                        name: "FK_RewardRemovedCards_CardRecords_CardRecordId",
                        column: x => x.CardRecordId,
                        principalTable: "CardRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RewardRemovedCards_RewardRecords_CardRecordId",
                        column: x => x.CardRecordId,
                        principalTable: "RewardRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RewardUpgradedCards",
                columns: table => new
                {
                    RewardRecordId = table.Column<int>(type: "integer", nullable: false),
                    CardRecordId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardUpgradedCards", x => new { x.RewardRecordId, x.CardRecordId });
                    table.ForeignKey(
                        name: "FK_RewardUpgradedCards_CardRecords_CardRecordId",
                        column: x => x.CardRecordId,
                        principalTable: "CardRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RewardUpgradedCards_RewardRecords_CardRecordId",
                        column: x => x.CardRecordId,
                        principalTable: "RewardRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleRecord_BattleInstanceId",
                table: "BattleRecord",
                column: "BattleInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CardChoiceCards_CardInstanceId",
                table: "CardChoiceCards",
                column: "CardInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CardChoiceRecord_CardPickedId",
                table: "CardChoiceRecord",
                column: "CardPickedId");

            migrationBuilder.CreateIndex(
                name: "IX_CardChoiceRecord_RewardRecordId",
                table: "CardChoiceRecord",
                column: "RewardRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CardRecords_CardInstanceId",
                table: "CardRecords",
                column: "CardInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CardRecords_CharacterRecordId",
                table: "CardRecords",
                column: "CharacterRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRecord_CharacterInstanceId",
                table: "CharacterRecord",
                column: "CharacterInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRecord_GameResultId",
                table: "CharacterRecord",
                column: "GameResultId");

            migrationBuilder.CreateIndex(
                name: "IX_EventChoiceInstance_EventId",
                table: "EventChoiceInstance",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRecords_EventInstanceId",
                table: "EventRecords",
                column: "EventInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PassiveRecords_GameResultId",
                table: "PassiveRecords",
                column: "GameResultId");

            migrationBuilder.CreateIndex(
                name: "IX_PassiveRecords_PassiveInstanceId",
                table: "PassiveRecords",
                column: "PassiveInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PassiveRecords_RewardRecordId",
                table: "PassiveRecords",
                column: "RewardRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RerolledCardCardInstances_CardInstanceId",
                table: "RerolledCardCardInstances",
                column: "CardInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardGivenTradeCards_CardRecordId",
                table: "RewardGivenTradeCards",
                column: "CardRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardJunkCards_CardRecordId",
                table: "RewardJunkCards",
                column: "CardRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardRecievedTradeCards_CardRecordId",
                table: "RewardRecievedTradeCards",
                column: "CardRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardRemovedCards_CardRecordId",
                table: "RewardRemovedCards",
                column: "CardRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardUpgradedCards_CardRecordId",
                table: "RewardUpgradedCards",
                column: "CardRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRecords_BattleRecordId",
                table: "RoomRecords",
                column: "BattleRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRecords_EventRecordId",
                table: "RoomRecords",
                column: "EventRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRecords_GameResultId",
                table: "RoomRecords",
                column: "GameResultId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRecords_RewardRecordId",
                table: "RoomRecords",
                column: "RewardRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRecords_ShopRecordId",
                table: "RoomRecords",
                column: "ShopRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopAffordableCards_CardInstanceId",
                table: "ShopAffordableCards",
                column: "CardInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopAffordablePassives_PassiveRecordId",
                table: "ShopAffordablePassives",
                column: "PassiveRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopPurchasedCards_CardInstanceId",
                table: "ShopPurchasedCards",
                column: "CardInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopPurchasedPassives_PassiveRecordId",
                table: "ShopPurchasedPassives",
                column: "PassiveRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardChoiceCards");

            migrationBuilder.DropTable(
                name: "EventChoiceInstance");

            migrationBuilder.DropTable(
                name: "RerolledCardCardInstances");

            migrationBuilder.DropTable(
                name: "RewardGivenTradeCards");

            migrationBuilder.DropTable(
                name: "RewardJunkCards");

            migrationBuilder.DropTable(
                name: "RewardRecievedTradeCards");

            migrationBuilder.DropTable(
                name: "RewardRemovedCards");

            migrationBuilder.DropTable(
                name: "RewardUpgradedCards");

            migrationBuilder.DropTable(
                name: "RoomRecords");

            migrationBuilder.DropTable(
                name: "ShopAffordableCards");

            migrationBuilder.DropTable(
                name: "ShopAffordablePassives");

            migrationBuilder.DropTable(
                name: "ShopPurchasedCards");

            migrationBuilder.DropTable(
                name: "ShopPurchasedPassives");

            migrationBuilder.DropTable(
                name: "CardChoiceRecord");

            migrationBuilder.DropTable(
                name: "CardRecords");

            migrationBuilder.DropTable(
                name: "BattleRecord");

            migrationBuilder.DropTable(
                name: "EventRecords");

            migrationBuilder.DropTable(
                name: "PassiveRecords");

            migrationBuilder.DropTable(
                name: "ShopRecords");

            migrationBuilder.DropTable(
                name: "CardInstance");

            migrationBuilder.DropTable(
                name: "CharacterRecord");

            migrationBuilder.DropTable(
                name: "BattleInstance");

            migrationBuilder.DropTable(
                name: "EventInstance");

            migrationBuilder.DropTable(
                name: "PassiveInstance");

            migrationBuilder.DropTable(
                name: "RewardRecords");

            migrationBuilder.DropTable(
                name: "CharacterInstances");

            migrationBuilder.DropTable(
                name: "GameResults");
        }
    }
}
