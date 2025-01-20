using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingTrackerSupreme.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinningPlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Players_WinningPlayerId",
                        column: x => x.WinningPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayer",
                columns: table => new
                {
                    GameParticipationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayer", x => new { x.GameParticipationId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_GamePlayer_Games_GameParticipationId",
                        column: x => x.GameParticipationId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayer_Players_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstRollId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondRollId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FrameNumber = table.Column<int>(type: "int", nullable: false),
                    PlayerGameGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlayerGamePlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstFrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SecondFrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThirdFrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FourthFrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FifthFrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SixthFrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SeventhFrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EightFrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NinthFrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenthFrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_PlayerGames_Frames_EightFrameId",
                        column: x => x.EightFrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Frames_FifthFrameId",
                        column: x => x.FifthFrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Frames_FirstFrameId",
                        column: x => x.FirstFrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Frames_FourthFrameId",
                        column: x => x.FourthFrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Frames_NinthFrameId",
                        column: x => x.NinthFrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Frames_SecondFrameId",
                        column: x => x.SecondFrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Frames_SeventhFrameId",
                        column: x => x.SeventhFrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Frames_SixthFrameId",
                        column: x => x.SixthFrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Frames_TenthFrameId",
                        column: x => x.TenthFrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Frames_ThirdFrameId",
                        column: x => x.ThirdFrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rolls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PinsHit = table.Column<int>(type: "int", nullable: false),
                    FrameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rolls_Frames_FrameId",
                        column: x => x.FrameId,
                        principalTable: "Frames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frames_FirstRollId",
                table: "Frames",
                column: "FirstRollId");

            migrationBuilder.CreateIndex(
                name: "IX_Frames_PlayerGamePlayerId_PlayerGameGameId",
                table: "Frames",
                columns: new[] { "PlayerGamePlayerId", "PlayerGameGameId" });

            migrationBuilder.CreateIndex(
                name: "IX_Frames_SecondRollId",
                table: "Frames",
                column: "SecondRollId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_ParticipantsId",
                table: "GamePlayer",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinningPlayerId",
                table: "Games",
                column: "WinningPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_EightFrameId",
                table: "PlayerGames",
                column: "EightFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_FifthFrameId",
                table: "PlayerGames",
                column: "FifthFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_FirstFrameId",
                table: "PlayerGames",
                column: "FirstFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_FourthFrameId",
                table: "PlayerGames",
                column: "FourthFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_GameId",
                table: "PlayerGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_NinthFrameId",
                table: "PlayerGames",
                column: "NinthFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_SecondFrameId",
                table: "PlayerGames",
                column: "SecondFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_SeventhFrameId",
                table: "PlayerGames",
                column: "SeventhFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_SixthFrameId",
                table: "PlayerGames",
                column: "SixthFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_TenthFrameId",
                table: "PlayerGames",
                column: "TenthFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_ThirdFrameId",
                table: "PlayerGames",
                column: "ThirdFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_Rolls_FrameId",
                table: "Rolls",
                column: "FrameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_PlayerGames_PlayerGamePlayerId_PlayerGameGameId",
                table: "Frames",
                columns: new[] { "PlayerGamePlayerId", "PlayerGameGameId" },
                principalTable: "PlayerGames",
                principalColumns: new[] { "PlayerId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_Rolls_FirstRollId",
                table: "Frames",
                column: "FirstRollId",
                principalTable: "Rolls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_Rolls_SecondRollId",
                table: "Frames",
                column: "SecondRollId",
                principalTable: "Rolls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frames_PlayerGames_PlayerGamePlayerId_PlayerGameGameId",
                table: "Frames");

            migrationBuilder.DropForeignKey(
                name: "FK_Frames_Rolls_FirstRollId",
                table: "Frames");

            migrationBuilder.DropForeignKey(
                name: "FK_Frames_Rolls_SecondRollId",
                table: "Frames");

            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Rolls");

            migrationBuilder.DropTable(
                name: "Frames");
        }
    }
}
