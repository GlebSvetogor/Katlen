using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katlen.WEB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KatlenUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatlenUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDALId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_KatlenUsers_UserDALId",
                        column: x => x.UserDALId,
                        principalTable: "KatlenUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ImgSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    FullPrice = table.Column<int>(type: "int", nullable: false),
                    OrderDALId = table.Column<int>(type: "int", nullable: true),
                    UserDALId = table.Column<int>(type: "int", nullable: true),
                    UserDALId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_KatlenUsers_UserDALId",
                        column: x => x.UserDALId,
                        principalTable: "KatlenUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_KatlenUsers_UserDALId1",
                        column: x => x.UserDALId1,
                        principalTable: "KatlenUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderDALId",
                        column: x => x.OrderDALId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_KatlenUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "KatlenUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserDALId",
                table: "Orders",
                column: "UserDALId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderDALId",
                table: "Products",
                column: "OrderDALId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserDALId",
                table: "Products",
                column: "UserDALId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserDALId1",
                table: "Products",
                column: "UserDALId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "KatlenUsers");
        }
    }
}
