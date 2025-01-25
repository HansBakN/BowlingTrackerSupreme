using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingTrackerSupreme.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedScoreToFrame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Frames",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Frames");
        }
    }
}
