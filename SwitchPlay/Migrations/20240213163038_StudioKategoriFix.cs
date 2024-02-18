using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchPlay.Migrations
{
    /// <inheritdoc />
    public partial class StudioKategoriFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudioCategory_Categories_CategoryId",
                table: "StudioCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_StudioCategory_Studios_StudioId",
                table: "StudioCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudioCategory",
                table: "StudioCategory");

            migrationBuilder.RenameTable(
                name: "StudioCategory",
                newName: "StudioCategories");

            migrationBuilder.RenameIndex(
                name: "IX_StudioCategory_StudioId",
                table: "StudioCategories",
                newName: "IX_StudioCategories_StudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudioCategories",
                table: "StudioCategories",
                columns: new[] { "CategoryId", "StudioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudioCategories_Categories_CategoryId",
                table: "StudioCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudioCategories_Studios_StudioId",
                table: "StudioCategories",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudioCategories_Categories_CategoryId",
                table: "StudioCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_StudioCategories_Studios_StudioId",
                table: "StudioCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudioCategories",
                table: "StudioCategories");

            migrationBuilder.RenameTable(
                name: "StudioCategories",
                newName: "StudioCategory");

            migrationBuilder.RenameIndex(
                name: "IX_StudioCategories_StudioId",
                table: "StudioCategory",
                newName: "IX_StudioCategory_StudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudioCategory",
                table: "StudioCategory",
                columns: new[] { "CategoryId", "StudioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudioCategory_Categories_CategoryId",
                table: "StudioCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudioCategory_Studios_StudioId",
                table: "StudioCategory",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
