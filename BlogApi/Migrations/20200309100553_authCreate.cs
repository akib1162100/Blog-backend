using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApi.Migrations
{
    public partial class authCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_AuthorId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
