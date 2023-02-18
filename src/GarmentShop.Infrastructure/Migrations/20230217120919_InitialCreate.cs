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
                    PaymentDate = table.Column<DateTime>(name: "Payment_Date", type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(name: "Payment_Amount", type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
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
                    { new Guid("2d25cec7-d3d6-449d-a03d-70b8d0f27b92"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5864), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5865), "Manager", 1 },
                    { new Guid("873299d9-e0be-4fc2-89ff-7952ae603174"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5854), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5860), "Customer", 0 },
                    { new Guid("94995d3a-f7f4-4e9c-9f25-c15a12be955f"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5868), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5870), "Admin", 2 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "ModifiedDate", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("0d618911-8591-45ee-8c56-ea05820a5390"), new Guid("873299d9-e0be-4fc2-89ff-7952ae603174"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5407), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5409), "ViewOrderHistory", 2 },
                    { new Guid("22668925-fad1-4bd2-8fce-5152157b8b06"), new Guid("94995d3a-f7f4-4e9c-9f25-c15a12be955f"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5444), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5446), "ManageCustomers", 7 },
                    { new Guid("24661828-46b5-456b-a7e8-b40e2ce4b660"), new Guid("2d25cec7-d3d6-449d-a03d-70b8d0f27b92"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5419), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5421), "EditItems", 4 },
                    { new Guid("3787eecc-7b14-4c66-886e-cf5a3aa14270"), new Guid("873299d9-e0be-4fc2-89ff-7952ae603174"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5413), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5415), "UpdateShippingAddress", 3 },
                    { new Guid("39c92b90-1af0-496f-9de5-0fa7babcab37"), new Guid("873299d9-e0be-4fc2-89ff-7952ae603174"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5401), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5403), "PlaceOrder", 1 },
                    { new Guid("4fa7da2b-5364-4c63-a095-ddb805f38946"), new Guid("2d25cec7-d3d6-449d-a03d-70b8d0f27b92"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5433), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5434), "DeleteItems", 5 },
                    { new Guid("53543dc3-b5a6-41f1-83ac-90e4e54778c9"), new Guid("2d25cec7-d3d6-449d-a03d-70b8d0f27b92"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5439), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5440), "AddItems", 6 },
                    { new Guid("5f5c9eeb-b41d-4e67-a34b-4c0bf93ec9a0"), new Guid("94995d3a-f7f4-4e9c-9f25-c15a12be955f"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5467), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5469), "ManageOrders", 11 },
                    { new Guid("9925f28f-4606-4cef-9117-19693fa49c5c"), new Guid("94995d3a-f7f4-4e9c-9f25-c15a12be955f"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5462), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5463), "ManagePermissions", 10 },
                    { new Guid("a95eae0f-c7f4-408d-8010-b3d031bd837f"), new Guid("94995d3a-f7f4-4e9c-9f25-c15a12be955f"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5456), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5458), "ManageRoles", 9 },
                    { new Guid("ae370106-f7ff-4c78-9b7c-e691a4385913"), new Guid("94995d3a-f7f4-4e9c-9f25-c15a12be955f"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5450), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5452), "ManageUsers", 8 },
                    { new Guid("e8363d05-f28d-4447-b022-953f8f63d7ce"), new Guid("873299d9-e0be-4fc2-89ff-7952ae603174"), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5332), new DateTime(2023, 2, 17, 14, 9, 19, 432, DateTimeKind.Local).AddTicks(5396), "AddToCart", 0 }
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
