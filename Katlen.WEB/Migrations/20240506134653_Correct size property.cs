using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katlen.WEB.Migrations
{
    /// <inheritdoc />
    public partial class Correctsizeproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_KatlenUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_KatlenUsers_UserDALId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_KatlenUsers_UserDALId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_KatlenUsers_UserDALId1",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KatlenUsers",
                table: "KatlenUsers");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "KatlenUsers",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Products",
                newName: "SizesAreAvailable");

            migrationBuilder.AddColumn<string>(
                name: "Sizes",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserDALId",
                table: "Orders",
                column: "UserDALId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserDALId",
                table: "Products",
                column: "UserDALId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserDALId1",
                table: "Products",
                column: "UserDALId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserDALId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserDALId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserDALId1",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Sizes",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "KatlenUsers");

            migrationBuilder.RenameColumn(
                name: "SizesAreAvailable",
                table: "Products",
                newName: "Size");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KatlenUsers",
                table: "KatlenUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_KatlenUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "KatlenUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_KatlenUsers_UserDALId",
                table: "Orders",
                column: "UserDALId",
                principalTable: "KatlenUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_KatlenUsers_UserDALId",
                table: "Products",
                column: "UserDALId",
                principalTable: "KatlenUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_KatlenUsers_UserDALId1",
                table: "Products",
                column: "UserDALId1",
                principalTable: "KatlenUsers",
                principalColumn: "Id");
        }
    }
}
