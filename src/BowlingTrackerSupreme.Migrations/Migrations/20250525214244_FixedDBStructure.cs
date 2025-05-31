using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingTrackerSupreme.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FixedDBStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frames_PlayerGames_PlayerGameId",
                table: "Frames");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WinningPlayerId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_WinningPlayerId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Frames",
                table: "Frames");

            migrationBuilder.DropIndex(
                name: "IX_Frames_PlayerGameId",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "WinningPlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "FirstRollId",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "PlayerGameId",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "SecondRoll_PinsHit",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "ThirdRoll_PinsHit",
                table: "Frames");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "PlayerSet");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "GameSet");

            migrationBuilder.RenameTable(
                name: "Frames",
                newName: "FrameSet");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PlayerSet",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "SecondRollId",
                table: "FrameSet",
                newName: "GamePlayerId");

            migrationBuilder.RenameColumn(
                name: "FrameNumber",
                table: "FrameSet",
                newName: "ThirdRoll");

            migrationBuilder.RenameColumn(
                name: "FirstRoll_PinsHit",
                table: "FrameSet",
                newName: "SecondRoll");

            migrationBuilder.AddColumn<int>(
                name: "GameNumber",
                table: "GameSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lane",
                table: "GameSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "FrameSet",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccumulatedScore",
                table: "FrameSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstRoll",
                table: "FrameSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "FrameSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerSet",
                table: "PlayerSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameSet",
                table: "GameSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FrameSet",
                table: "FrameSet",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlayerNicknameSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerNicknameSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerNicknameSet_PlayerSet_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayerSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerNicknameId = table.Column<Guid>(type: "uuid", nullable: true),
                    TotalScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayerSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlayerSet_GameSet_GameId",
                        column: x => x.GameId,
                        principalTable: "GameSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayerSet_PlayerNicknameSet_PlayerNicknameId",
                        column: x => x.PlayerNicknameId,
                        principalTable: "PlayerNicknameSet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GamePlayerSet_PlayerSet_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FrameSet_GamePlayerId",
                table: "FrameSet",
                column: "GamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerSet_GameId",
                table: "GamePlayerSet",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerSet_PlayerId",
                table: "GamePlayerSet",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerSet_PlayerNicknameId",
                table: "GamePlayerSet",
                column: "PlayerNicknameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerNicknameSet_PlayerId",
                table: "PlayerNicknameSet",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FrameSet_GamePlayerSet_GamePlayerId",
                table: "FrameSet",
                column: "GamePlayerId",
                principalTable: "GamePlayerSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FrameSet_GamePlayerSet_GamePlayerId",
                table: "FrameSet");

            migrationBuilder.DropTable(
                name: "GamePlayerSet");

            migrationBuilder.DropTable(
                name: "PlayerNicknameSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerSet",
                table: "PlayerSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameSet",
                table: "GameSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FrameSet",
                table: "FrameSet");

            migrationBuilder.DropIndex(
                name: "IX_FrameSet_GamePlayerId",
                table: "FrameSet");

            migrationBuilder.DropColumn(
                name: "GameNumber",
                table: "GameSet");

            migrationBuilder.DropColumn(
                name: "Lane",
                table: "GameSet");

            migrationBuilder.DropColumn(
                name: "AccumulatedScore",
                table: "FrameSet");

            migrationBuilder.DropColumn(
                name: "FirstRoll",
                table: "FrameSet");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "FrameSet");

            migrationBuilder.RenameTable(
                name: "PlayerSet",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "GameSet",
                newName: "Games");

            migrationBuilder.RenameTable(
                name: "FrameSet",
                newName: "Frames");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Players",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ThirdRoll",
                table: "Frames",
                newName: "FrameNumber");

            migrationBuilder.RenameColumn(
                name: "SecondRoll",
                table: "Frames",
                newName: "FirstRoll_PinsHit");

            migrationBuilder.RenameColumn(
                name: "GamePlayerId",
                table: "Frames",
                newName: "SecondRollId");

            migrationBuilder.AddColumn<Guid>(
                name: "WinningPlayerId",
                table: "Games",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Frames",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Frames",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Frames",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FirstRollId",
                table: "Frames",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Frames",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerGameId",
                table: "Frames",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SecondRoll_PinsHit",
                table: "Frames",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThirdRoll_PinsHit",
                table: "Frames",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Frames",
                table: "Frames",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GamePlayer",
                columns: table => new
                {
                    GameParticipationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantsId = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "PlayerGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinningPlayerId",
                table: "Games",
                column: "WinningPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Frames_PlayerGameId",
                table: "Frames",
                column: "PlayerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_ParticipantsId",
                table: "GamePlayer",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_GameId",
                table: "PlayerGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayerId",
                table: "PlayerGames",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_PlayerGames_PlayerGameId",
                table: "Frames",
                column: "PlayerGameId",
                principalTable: "PlayerGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WinningPlayerId",
                table: "Games",
                column: "WinningPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
