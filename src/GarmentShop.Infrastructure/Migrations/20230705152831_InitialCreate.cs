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
                    { new Guid("190b6d37-d520-4fdb-b94b-5019fb3f9fdd"), new DateTime(2023, 7, 5, 18, 28, 31, 269, DateTimeKind.Local).AddTicks(193), new DateTime(2023, 7, 5, 18, 28, 31, 269, DateTimeKind.Local).AddTicks(195), "Admin", 2 },
                    { new Guid("32e1061f-d645-490f-bc44-74315924b781"), new DateTime(2023, 7, 5, 18, 28, 31, 269, DateTimeKind.Local).AddTicks(177), new DateTime(2023, 7, 5, 18, 28, 31, 269, DateTimeKind.Local).AddTicks(184), "Customer", 0 },
                    { new Guid("ddcc9ff1-5e42-4f3b-9e36-cc4759b74477"), new DateTime(2023, 7, 5, 18, 28, 31, 269, DateTimeKind.Local).AddTicks(188), new DateTime(2023, 7, 5, 18, 28, 31, 269, DateTimeKind.Local).AddTicks(189), "Manager", 1 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "ModifiedDate", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("11dfa449-ace9-4dc0-b44a-9f406ecdb4a8"), new Guid("32e1061f-d645-490f-bc44-74315924b781"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9724), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9726), "UpdateShippingAddress", 3 },
                    { new Guid("239c787d-0019-48b6-8a80-2471aa41fc77"), new Guid("190b6d37-d520-4fdb-b94b-5019fb3f9fdd"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9750), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9752), "ManageCustomers", 7 },
                    { new Guid("38f5f2bd-32ca-4abe-8cdd-0b6d92483605"), new Guid("190b6d37-d520-4fdb-b94b-5019fb3f9fdd"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9769), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9771), "ManagePermissions", 10 },
                    { new Guid("3c3e0d7a-d68b-46ae-8d05-754744c64d7b"), new Guid("32e1061f-d645-490f-bc44-74315924b781"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9699), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9701), "PlaceOrder", 1 },
                    { new Guid("46ee5ad0-37ce-4830-9ec9-0e7044ce49c5"), new Guid("ddcc9ff1-5e42-4f3b-9e36-cc4759b74477"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9744), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9746), "AddItems", 6 },
                    { new Guid("6adcd048-e86b-450a-80ea-190b724474d2"), new Guid("190b6d37-d520-4fdb-b94b-5019fb3f9fdd"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9763), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9765), "ManageRoles", 9 },
                    { new Guid("6fe33040-d046-4819-bee9-26556f1ef64b"), new Guid("190b6d37-d520-4fdb-b94b-5019fb3f9fdd"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9779), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9781), "ManageOrders", 11 },
                    { new Guid("8b3340ec-435b-4bb1-a27c-7979a858b3f4"), new Guid("ddcc9ff1-5e42-4f3b-9e36-cc4759b74477"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9731), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9733), "EditItems", 4 },
                    { new Guid("ba20263f-5ab4-4f5c-b079-738e9873ca60"), new Guid("32e1061f-d645-490f-bc44-74315924b781"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9636), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9692), "AddToCart", 0 },
                    { new Guid("c5306f2a-c5d6-43f2-9529-5fbf04f60bcf"), new Guid("190b6d37-d520-4fdb-b94b-5019fb3f9fdd"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9756), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9758), "ManageUsers", 8 },
                    { new Guid("e0eeeb28-e09a-43d2-8ce8-07f4af6877e2"), new Guid("32e1061f-d645-490f-bc44-74315924b781"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9705), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9707), "ViewOrderHistory", 2 },
                    { new Guid("f0298703-e812-4cd1-866e-79272131bab7"), new Guid("ddcc9ff1-5e42-4f3b-9e36-cc4759b74477"), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9738), new DateTime(2023, 7, 5, 18, 28, 31, 268, DateTimeKind.Local).AddTicks(9739), "DeleteItems", 5 }
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
