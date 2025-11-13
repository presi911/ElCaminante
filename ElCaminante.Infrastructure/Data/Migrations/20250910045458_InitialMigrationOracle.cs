using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElCaminante.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationOracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ELCAMINANTE");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "ELCAMINANTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalFee = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "ELCAMINANTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    AvailableStock = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Size = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    Rating = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: true),
                    Material = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ProductType = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                schema: "ELCAMINANTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "ELCAMINANTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ProductId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Quantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    OrderId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "ELCAMINANTE",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ELCAMINANTE",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                schema: "ELCAMINANTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ProductId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Quantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SelectedForOrder = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ELCAMINANTE",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "ELCAMINANTE",
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Id",
                schema: "ELCAMINANTE",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                schema: "ELCAMINANTE",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                schema: "ELCAMINANTE",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id",
                schema: "ELCAMINANTE",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                schema: "ELCAMINANTE",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_Id",
                schema: "ELCAMINANTE",
                table: "ShoppingCartItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                schema: "ELCAMINANTE",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                schema: "ELCAMINANTE",
                table: "ShoppingCartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_Id",
                schema: "ELCAMINANTE",
                table: "ShoppingCarts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "ELCAMINANTE");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems",
                schema: "ELCAMINANTE");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "ELCAMINANTE");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "ELCAMINANTE");

            migrationBuilder.DropTable(
                name: "ShoppingCarts",
                schema: "ELCAMINANTE");
        }
    }
}
