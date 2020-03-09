using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApi.Migrations
{
    public partial class UserCreatenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AuthorDTO_AuthorId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "AuthorDTO");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_AuthorId",
                table: "Blogs");

            migrationBuilder.CreateTable(
                name: "AuthorDTO",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorDTO", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AuthorDTO_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "AuthorDTO",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
