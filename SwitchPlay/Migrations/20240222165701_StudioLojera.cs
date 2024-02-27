using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchPlay.Migrations
{
    /// <inheritdoc />
    public partial class StudioLojera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudioId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_StudioId",
                table: "Games",
                column: "StudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Studios_StudioId",
                table: "Games",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Studios_StudioId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_StudioId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StudioId",
                table: "Games");
        }
    }
}
