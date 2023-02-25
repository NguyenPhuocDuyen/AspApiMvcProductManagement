using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObject.Migrations
{
    public partial class DbInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Beverages" },
                    { 2, "Condiments" },
                    { 3, "Confections" },
                    { 4, "KATANA" },
                    { 5, "FuShi" },
                    { 6, "MaleWe" },
                    { 7, "Posia" },
                    { 8, "CamDaka" },
                    { 9, "Rikiko" },
                    { 10, "Grains/Cereals" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "City", "CompanyName", "Country", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "Can Tho", "ABC", "Viet Nam", "cus1@gmail.com", "cus1@gmail.com" },
                    { 2, "MaBu", "Hung Thinh", "HaWai", "cus2@gmail.com", "cus2@gmail.com" },
                    { 3, "HaTi", "Hoang Thanh", "New Tork", "cus3@gmail.com", "cus3@gmail.com" },
                    { 4, "KuBa", "Iuke", "Canada", "cus4@gmail.com", "cus4@gmail.com" },
                    { 5, "AVC", "AVC", "Japan", "cus5@gmail.com", "cus5@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "MemberId", "OrderDate", "RequiredDate", "ShippedDate" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6433), new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6434), new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6435) },
                    { 2, 2, new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6429), new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6431), new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6432) },
                    { 1, 3, new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(590), new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(5854), new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(5864) },
                    { 4, 4, new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6436), new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6436), new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6437) },
                    { 5, 5, new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6438), new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6439), new DateTime(2023, 2, 7, 12, 40, 12, 286, DateTimeKind.Local).AddTicks(6440) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductName", "UnitPrice", "UnitsInStock", "Weight" },
                values: new object[,]
                {
                    { 5, 1, "Cuc Gach", 50, 5, 50 },
                    { 4, 2, "Huwai", 40, 4, 40 },
                    { 3, 3, "Nokia", 30, 3, 30 },
                    { 2, 4, "Sam Sung", 20, 2, 20 },
                    { 1, 5, "Iphone", 10, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId", "Discount", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 3, 5, 10, 11, 100 },
                    { 3, 1, 10, 55, 12 },
                    { 2, 3, 10, 22, 99 },
                    { 2, 4, 10, 44, 77 },
                    { 1, 2, 10, 33, 88 },
                    { 4, 2, 10, 44, 53 },
                    { 4, 3, 10, 88, 22 },
                    { 5, 4, 10, 23, 76 },
                    { 5, 5, 10, 44, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MemberId",
                table: "Orders",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
