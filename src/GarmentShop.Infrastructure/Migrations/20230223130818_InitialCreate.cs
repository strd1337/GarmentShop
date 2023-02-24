using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarmentShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GarmentCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GarmentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GarmentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessageConsumers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessageConsumers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OccurredOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.PermissionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrders",
                columns: table => new
                {
                    SaleOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ShippingAndHandling = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    OtherCharges = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrders", x => new { x.SaleOrderId, x.SaleId });
                    table.ForeignKey(
                        name: "FK_SaleOrders_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserRoleId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSaleIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSaleIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSaleIds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderItemId, x.SaleOrderId, x.SaleId });
                    table.ForeignKey(
                        name: "FK_OrderItems_SaleOrders_SaleOrderId_SaleId",
                        columns: x => new { x.SaleOrderId, x.SaleId },
                        principalTable: "SaleOrders",
                        principalColumns: new[] { "SaleOrderId", "SaleId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("274948e2-efa8-4248-9f1f-5073ae056d9d"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9807), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9809), "Admin", 2 },
                    { new Guid("729d3423-6250-46fe-aaee-b031e7e13ee3"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9791), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9798), "Customer", 0 },
                    { new Guid("ba6d0919-1e52-449a-a4b5-3d196eaf28e0"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9802), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9804), "Manager", 1 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "ModifiedDate", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("04797320-c4b7-41e7-b6fb-2479c16b6cfb"), new Guid("274948e2-efa8-4248-9f1f-5073ae056d9d"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9383), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9384), "ManageUsers", 8 },
                    { new Guid("0c873692-42d0-4379-b428-d6b6f1104fe4"), new Guid("274948e2-efa8-4248-9f1f-5073ae056d9d"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9406), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9408), "ManageOrders", 11 },
                    { new Guid("15d1cf25-485d-4f4b-82c1-a46559de30d5"), new Guid("729d3423-6250-46fe-aaee-b031e7e13ee3"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9268), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9321), "AddToCart", 0 },
                    { new Guid("4a692ebf-3664-4f22-88c6-a0b8c46e3357"), new Guid("729d3423-6250-46fe-aaee-b031e7e13ee3"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9352), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9354), "UpdateShippingAddress", 3 },
                    { new Guid("5dec5f96-76ef-4c87-8aba-b06aed16aaef"), new Guid("729d3423-6250-46fe-aaee-b031e7e13ee3"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9326), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9328), "PlaceOrder", 1 },
                    { new Guid("5faa0d50-4753-4e23-9cff-bc82deed6ceb"), new Guid("729d3423-6250-46fe-aaee-b031e7e13ee3"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9345), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9347), "ViewOrderHistory", 2 },
                    { new Guid("736ffe87-d3b5-49a0-9f2b-b12d35e69d22"), new Guid("ba6d0919-1e52-449a-a4b5-3d196eaf28e0"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9364), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9366), "DeleteItems", 5 },
                    { new Guid("7d7b3a00-df3f-4ad7-8603-d22ba079b9c9"), new Guid("ba6d0919-1e52-449a-a4b5-3d196eaf28e0"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9370), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9372), "AddItems", 6 },
                    { new Guid("80bc6902-e761-48c6-8e86-38bfbc3650f7"), new Guid("274948e2-efa8-4248-9f1f-5073ae056d9d"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9399), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9401), "ManagePermissions", 10 },
                    { new Guid("9ab90b85-3e3b-4042-bec2-20bbf4606fa0"), new Guid("ba6d0919-1e52-449a-a4b5-3d196eaf28e0"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9358), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9360), "EditItems", 4 },
                    { new Guid("a98a8e44-4528-48c1-9578-2bcec0561432"), new Guid("274948e2-efa8-4248-9f1f-5073ae056d9d"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9376), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9378), "ManageCustomers", 7 },
                    { new Guid("ed1764cf-dd7f-49d9-aeed-8e24e73129a7"), new Guid("274948e2-efa8-4248-9f1f-5073ae056d9d"), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9389), new DateTime(2023, 2, 23, 15, 8, 18, 745, DateTimeKind.Local).AddTicks(9391), "ManageRoles", 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SaleOrderId_SaleId",
                table: "OrderItems",
                columns: new[] { "SaleOrderId", "SaleId" });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_SaleId",
                table: "SaleOrders",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSaleIds_UserId",
                table: "UserSaleIds",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "GarmentCategories");

            migrationBuilder.DropTable(
                name: "Garments");

            migrationBuilder.DropTable(
                name: "GarmentTypes");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OutboxMessageConsumers");

            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserSaleIds");

            migrationBuilder.DropTable(
                name: "SaleOrders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
