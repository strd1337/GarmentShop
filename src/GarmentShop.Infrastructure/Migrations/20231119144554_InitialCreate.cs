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
                table: "GarmentCategories",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(6328), "Includes products specifically designed for young males.", new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(6330), "For Boys" },
                    { new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(6303), "Includes products specifically designed for mens.", new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(6317), "For Men" },
                    { new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(6324), "Includes products specifically designed for young females.", new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(6326), "For Girls" },
                    { new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(6320), "Includes products specifically designed for womens.", new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(6322), "For Women" }
                });

            migrationBuilder.InsertData(
                table: "GarmentTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "GarmentCategoryId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("0710eb81-a713-42e3-9a13-197e4a6e847f"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2858), "Comfortable, lightweight footwear for indoor use.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2860), "Slippers" },
                    { new Guid("077819d9-b591-4f1f-91b2-16e7adb883a8"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2852), "Footwear that covers the foot and ankle, often made of leather or rubber.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2854), "Boots" },
                    { new Guid("104721fa-f022-43a6-8615-3c5b8c78e816"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2620), "Knitted or crocheted garments worn on the upper body for warmth.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2622), "Sweaters" },
                    { new Guid("15d2dc2f-1adb-4ff8-a8b3-4cad73f28c2f"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2697), "Open-toed footwear with straps or thongs, suitable for warm weather.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2699), "Sandals" },
                    { new Guid("1d49b07a-4d6d-4b68-8bc3-b522358aa03e"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2810), "Denim trousers, typically made of heavy cotton, with sturdy seams and pockets.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2812), "Jeans" },
                    { new Guid("22e88cb6-d547-41fa-a18b-50c0202f2d9e"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2779), "Open-toed footwear with straps or thongs, suitable for warm weather.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2781), "Sandals" },
                    { new Guid("24e0f452-b115-4c5f-b01f-9e718d719340"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2571), "Garments that cover the body from the waist to the knees, typically worn in warm weather.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2573), "Shorts" },
                    { new Guid("2615a317-357f-4e70-ac0f-9a108a4ffcfe"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2565), "Short coat with sleeves, often lightweight and designed for specific purposes.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2567), "Jackets" },
                    { new Guid("2a5cb8bb-d93b-4633-bc77-55ad77880e41"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2734), "Denim trousers, typically made of heavy cotton, with sturdy seams and pockets.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2736), "Jeans" },
                    { new Guid("33d5034d-ffd9-4bd2-8fa4-7cc8b10ab62b"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2833), "Clothing suitable for sports or casual activities.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2835), "Sportswear" },
                    { new Guid("3b2a8c72-bcff-4b7e-b8c1-cfb5eea2131d"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2657), "Short coat with sleeves, often lightweight and designed for specific purposes.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2659), "Jackets" },
                    { new Guid("3c36dae5-3727-42fc-928e-44a0e4d55e11"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2493), "Knitted or crocheted garments worn on the upper body for warmth.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2495), "Sweaters" },
                    { new Guid("3d156704-da9e-496b-89be-170c0b76f1d6"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2705), "One-piece garments for women, typically with a fitted top and a flared skirt.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2707), "Dresses" },
                    { new Guid("42d024ea-5aff-48a2-9c07-cebb7c8be9c6"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2632), "One-piece garments for women, typically with a fitted top and a flared skirt.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2634), "Dresses" },
                    { new Guid("4ebfeed8-4856-4f9d-b308-c1679c36189d"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2760), "Casual athletic shoes with a flexible sole, suitable for sports or everyday wear.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2762), "Sneakers" },
                    { new Guid("51e70609-0a71-4655-bf2c-14288b322b99"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2821), "Shorts designed for swimming or other water activities.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2823), "SwimTrunks" },
                    { new Guid("547eebba-1344-4f51-a367-397016cbbd8d"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2674), "Sleepwear, typically consisting of loose-fitting trousers and a top.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2676), "Pajamas" },
                    { new Guid("54a344ca-c3e6-4019-b31a-3a610ae6ca78"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2583), "Casual athletic shoes with a flexible sole, suitable for sports or everyday wear.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2584), "Sneakers" },
                    { new Guid("5620e701-4af2-423c-a18e-ac652eb0ec0c"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2680), "Casual athletic shoes with a flexible sole, suitable for sports or everyday wear.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2682), "Sneakers" },
                    { new Guid("61f7a53c-d955-41e6-ab9b-c2d4c02992fe"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2547), "General category for lower body garments covering each leg separately.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2549), "Pants" },
                    { new Guid("6724db4d-3369-4125-b6ad-a0468f0e1909"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2559), "Clothing suitable for sports or casual activities.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2561), "Sportswear" },
                    { new Guid("6a1fdafc-26b9-4fc5-a72b-5310b41ef336"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2785), "Garments designed for wear outside other clothes, such as coats and jackets.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2786), "Outerwear" },
                    { new Guid("6ca9fff3-dc13-45fc-9340-e5bc2003bd2b"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2773), "Comfortable, lightweight footwear for indoor use.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2775), "Slippers" },
                    { new Guid("6dd2d687-5ae3-497c-839d-251e8abe38c7"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2790), "Knitted or crocheted garments worn on the upper body for warmth.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2792), "Sweaters" },
                    { new Guid("6e53b8f1-0d63-4fd7-8e99-3f8fb2f6a5f0"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2626), "General category for lower body garments covering each leg separately.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2628), "Pants" },
                    { new Guid("71d7d2e3-4483-474c-b577-ffb701352090"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2599), "Soft leather shoes, often with a sole made of one piece.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2601), "Moccasins" },
                    { new Guid("7203d6a8-0ac9-4943-9768-433fd2e0346c"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2637), "Garments designed for wear outside other clothes, such as coats and jackets.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2639), "Outerwear" },
                    { new Guid("7709c02f-375f-4715-a7ba-566084c41b1f"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2669), "Garments worn around the waist, covering the lower body and often with a separate top.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2670), "Skirts" },
                    { new Guid("77f0984a-5dff-4da9-82fa-fa292a2465f3"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2754), "Sleepwear, typically consisting of loose-fitting trousers and a top.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2756), "Pajamas" },
                    { new Guid("81182365-04aa-41c0-bf40-5fcdbc0bc486"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2717), "Garments designed for wear outside other clothes, such as coats and jackets.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2719), "Outerwear" },
                    { new Guid("893c7fb4-fd90-4fa4-8a3f-74dd8aa00625"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2482), "Denim trousers, typically made of heavy cotton, with sturdy seams and pockets.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2484), "Jeans" },
                    { new Guid("8c62355e-9b7f-41ba-b373-1ebf29d8447e"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2729), "Knitted or crocheted garments worn on the upper body for warmth.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2731), "Sweaters" },
                    { new Guid("8c8be257-394f-45e7-a32b-e96e5df2e302"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2577), "Sleepwear, typically consisting of loose-fitting trousers and a top.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2579), "Pajamas" },
                    { new Guid("8e5d4837-e6d0-453b-b299-40c841a91ab1"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2685), "Footwear that covers the foot and ankle, often made of leather or rubber.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2687), "Boots" },
                    { new Guid("925ae526-ccad-4ab7-a917-655539f15c34"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2863), "Open-toed footwear with straps or thongs, suitable for warm weather.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2865), "Sandals" },
                    { new Guid("927c6722-a26a-4352-9036-c24e8e7a81da"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2796), "Short-sleeved, typically cotton, casual shirt with a round neckline.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2798), "TShirts" },
                    { new Guid("92c508fd-bb13-403c-9d9f-2bcf817ce900"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2816), "General category for lower body garments covering each leg separately.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2817), "Pants" },
                    { new Guid("9345d89f-cacb-4959-9e9d-6a34940c0edd"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2691), "Comfortable, lightweight footwear for indoor use.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2693), "Slippers" },
                    { new Guid("9df7cd94-5d88-483f-bcb9-00307c153307"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2663), "Clothing suitable for sports or casual activities.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2665), "Sportswear" },
                    { new Guid("9e12dc05-a9ad-40d2-8759-32372d873d31"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2488), "Garments designed for wear outside other clothes, such as coats and jackets.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2490), "Outerwear" },
                    { new Guid("a346086f-98ec-413e-bc3a-f5fc707c2f33"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2615), "Denim trousers, typically made of heavy cotton, with sturdy seams and pockets.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2616), "Jeans" },
                    { new Guid("a8e7b5bc-8082-42b1-9fe8-6be9b1d9011f"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2804), "Garments that cover the body from the waist to the knees, typically worn in warm weather.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2806), "Shorts" },
                    { new Guid("ad22a5d2-8ba2-48b3-a2b0-3a82a395a3d6"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2430), "General category for upper body garments with sleeves, often buttoned or collared.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2477), "Shirts" },
                    { new Guid("ad7cb629-805c-46e9-b740-cd0f6fdbff6f"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2746), "Garments that cover the body from the waist to the knees, typically worn in warm weather.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2748), "Shorts" },
                    { new Guid("af407409-d7fb-40a0-909b-293da5ef52cb"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2711), "General category for lower body garments covering each leg separately.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2713), "Pants" },
                    { new Guid("b1f1f9fb-8429-4870-b37e-10f852e03fd4"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2594), "Comfortable, lightweight footwear for indoor use.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2596), "Slippers" },
                    { new Guid("b6569a0e-7f29-4e88-b6c6-b6e5f53a9794"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2740), "Garments worn around the waist, covering the lower body and often with a separate top.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2742), "Skirts" },
                    { new Guid("bbdcf22b-f940-416f-a6d8-964892c9d4d8"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2649), "General category for upper body garments, including blouses, shirts, and sweaters.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2650), "Tops" },
                    { new Guid("c8937942-0ad1-47b2-9153-5a2ce27c73df"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2767), "Footwear that covers the foot and ankle, often made of leather or rubber.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2769), "Boots" },
                    { new Guid("cb3b02b7-3ecf-4c33-a43b-9ada7c547f9e"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2643), "Garments that cover the body from the waist to the knees, typically worn in warm weather.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2645), "Shorts" },
                    { new Guid("ded90707-3509-40eb-9b3a-fc781dcd2e62"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2588), "Footwear that covers the foot and ankle, often made of leather or rubber.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2590), "Boots" },
                    { new Guid("e01739b4-a251-4de5-8007-1fa85baed35e"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2609), "Short-sleeved, typically cotton, casual shirt with a round neckline.", new Guid("c8db0b12-0c6a-424e-857a-a5c4ce8b4876"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2611), "TShirts" },
                    { new Guid("e0b03fcc-a3c7-4212-aca6-2e7570002719"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2827), "General category for upper body garments with sleeves, often buttoned or collared.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2829), "Shirts" },
                    { new Guid("e3557e1d-7020-4680-8952-61c3b15d9446"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2838), "Sleepwear, typically consisting of loose-fitting trousers and a top.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2840), "Pajamas" },
                    { new Guid("e78a9629-7633-49ab-8200-989b8a99efde"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2844), "Casual athletic shoes with a flexible sole, suitable for sports or everyday wear.", new Guid("3696b812-b36b-4400-9271-bd3d27466049"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2846), "Sneakers" },
                    { new Guid("e9bd971a-1d82-4a47-82f3-649a1e5dee8f"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2541), "Short-sleeved, typically cotton, casual shirt with a round neckline.", new Guid("a062f965-8be6-4246-bed7-f14fb26cb386"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2543), "TShirts" },
                    { new Guid("ee60ea9f-4401-426d-bf10-64a46e00177b"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2723), "Short-sleeved, typically cotton, casual shirt with a round neckline.", new Guid("b45b6b96-d0ef-430c-bf8d-e46649485adf"), new DateTime(2023, 11, 19, 16, 45, 54, 838, DateTimeKind.Local).AddTicks(2725), "TShirts" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("6eaa891b-fa1d-4451-973e-c714411deda1"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(1340), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(1346), "Customer", 0 },
                    { new Guid("71c68edc-5e93-47d1-b5ab-1c4e351322f5"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(1354), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(1356), "Manager", 1 },
                    { new Guid("f55a934e-fb0d-4bb3-8211-787f2183d26e"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(1360), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(1361), "Admin", 2 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "ModifiedDate", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("1733f994-77eb-48e8-a389-5311f4312dfe"), new Guid("f55a934e-fb0d-4bb3-8211-787f2183d26e"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(802), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(804), "ManageCustomers", 7 },
                    { new Guid("421db341-8ea0-4875-8b52-1ed26972a623"), new Guid("6eaa891b-fa1d-4451-973e-c714411deda1"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(735), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(737), "ViewOrderHistory", 2 },
                    { new Guid("45d27273-2365-4860-a137-02532817486d"), new Guid("f55a934e-fb0d-4bb3-8211-787f2183d26e"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(824), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(826), "ManagePermissions", 10 },
                    { new Guid("472bc7c4-dae3-463c-b1b5-762d4c768303"), new Guid("6eaa891b-fa1d-4451-973e-c714411deda1"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(741), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(743), "UpdateShippingAddress", 3 },
                    { new Guid("4ac36a3b-ed8e-4fc3-aa94-46dab6c6ee4d"), new Guid("71c68edc-5e93-47d1-b5ab-1c4e351322f5"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(753), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(755), "DeleteItems", 5 },
                    { new Guid("664f0827-48da-46b6-8a93-3b03c6012e7e"), new Guid("f55a934e-fb0d-4bb3-8211-787f2183d26e"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(808), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(810), "ManageUsers", 8 },
                    { new Guid("834767cf-c28c-4d3c-8cdc-08864de590fd"), new Guid("f55a934e-fb0d-4bb3-8211-787f2183d26e"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(818), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(820), "ManageRoles", 9 },
                    { new Guid("cd7f3523-0402-492d-b278-16f01cf94286"), new Guid("f55a934e-fb0d-4bb3-8211-787f2183d26e"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(830), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(832), "ManageOrders", 11 },
                    { new Guid("ce92ab6c-3d7c-455d-8b26-922002ff9825"), new Guid("6eaa891b-fa1d-4451-973e-c714411deda1"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(656), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(711), "AddToCart", 0 },
                    { new Guid("e0b07f74-d2d6-496c-afc2-71a4a781b179"), new Guid("6eaa891b-fa1d-4451-973e-c714411deda1"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(728), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(731), "PlaceOrder", 1 },
                    { new Guid("e1c09865-b6fc-4d5e-9930-9fb019f64eee"), new Guid("71c68edc-5e93-47d1-b5ab-1c4e351322f5"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(759), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(761), "AddItems", 6 },
                    { new Guid("f0a6960c-9e4a-465d-b9a8-b3d70b6bf399"), new Guid("71c68edc-5e93-47d1-b5ab-1c4e351322f5"), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(747), new DateTime(2023, 11, 19, 16, 45, 54, 817, DateTimeKind.Local).AddTicks(749), "EditItems", 4 }
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
