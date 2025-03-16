using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingTrackerSupreme.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatedOnModifiedOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "DatePlayed",
                table: "Games",
                newName: "PlayedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Players",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Players",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "PlayerGames",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "PlayerGames",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Games",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Games",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Frames",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Frames",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "PlayerGames");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "PlayerGames");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Frames");

            migrationBuilder.RenameColumn(
                name: "PlayedOn",
                table: "Games",
                newName: "DatePlayed");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Games",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
