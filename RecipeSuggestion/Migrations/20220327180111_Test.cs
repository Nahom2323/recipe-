using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeSuggestion.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_UserInformations_AspNetUsers_UserId",
                table: "UserInformations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInformations_AspNetUsers_UserId",
                table: "UserInformations");
        }
    }
}
