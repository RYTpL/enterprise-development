using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Model.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerCardNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductGroup = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductWeight = table.Column<double>(type: "double", nullable: false),
                    ProductType = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProductPrice = table.Column<double>(type: "double", nullable: false),
                    DateStorage = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StoreName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StoreAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStores_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStores_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateSale = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Sum = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSales_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerCardNumber", "CustomerName" },
                values: new object[,]
                {
                    { 1, 111111, "Michelle Padilla" },
                    { 2, 222222, "Manuel Gomez" },
                    { 3, 333333, "Raymond Oliver" },
                    { 4, 444444, "Enrique Morgan" },
                    { 5, 555555, "Walter Mullins" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "DateStorage", "ProductGroup", "ProductName", "ProductPrice", "ProductType", "ProductWeight" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Milk", 89.0, false, 0.93999999999999995 },
                    { 2, new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Butter", 159.0, false, 0.93999999999999995 },
                    { 3, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Pasta", 109.0, true, 0.40000000000000002 },
                    { 4, new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Eggs", 96.0, false, 0.59999999999999998 },
                    { 5, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Bread", 36.0, false, 0.44 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "StoreAddress", "StoreName" },
                values: new object[,]
                {
                    { 1, "Polevaya 123", "Walmart" },
                    { 2, "Pushkina 1837", "Pyaterochka" },
                    { 3, "Kolotushkina 0", "Shestorochka" },
                    { 4, "Moskovskoye shosse 666", "Magnit" },
                    { 5, "Revolyutsionnaya 1917", "Perekrestok" }
                });

            migrationBuilder.InsertData(
                table: "ProductStores",
                columns: new[] { "Id", "ProductId", "Quantity", "StoreId" },
                values: new object[,]
                {
                    { 1, 1, 10, 2 },
                    { 2, 2, 2, 2 },
                    { 3, 3, 5, 2 },
                    { 4, 3, 15, 3 },
                    { 5, 4, 0, 2 },
                    { 6, 4, 20, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "CustomerId", "DateSale", "StoreId", "Sum" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 357.0 },
                    { 2, 1, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 221.0 },
                    { 3, 2, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 364.0 },
                    { 4, 3, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 284.0 },
                    { 5, 4, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 241.0 },
                    { 6, 5, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 364.0 },
                    { 7, 5, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 284.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductSales",
                columns: new[] { "Id", "ProductId", "Quantity", "SaleId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 4, 1, 2 },
                    { 5, 5, 1, 2 },
                    { 6, 1, 1, 2 },
                    { 7, 2, 1, 3 },
                    { 8, 3, 1, 3 },
                    { 9, 4, 1, 3 },
                    { 10, 5, 1, 4 },
                    { 11, 1, 1, 4 },
                    { 12, 2, 1, 4 },
                    { 13, 3, 1, 5 },
                    { 14, 4, 1, 5 },
                    { 15, 5, 1, 5 },
                    { 16, 2, 1, 6 },
                    { 17, 3, 1, 6 },
                    { 18, 4, 1, 6 },
                    { 19, 5, 1, 7 },
                    { 20, 1, 1, 7 },
                    { 21, 4, 1, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_ProductId",
                table: "ProductSales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_SaleId",
                table: "ProductSales",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStores_ProductId",
                table: "ProductStores",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStores_StoreId",
                table: "ProductStores",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_StoreId",
                table: "Sales",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSales");

            migrationBuilder.DropTable(
                name: "ProductStores");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
