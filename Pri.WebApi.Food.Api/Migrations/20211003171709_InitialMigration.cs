using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pri.WebApi.Food.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(90), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(284), "Pizza" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(453), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(454), "Pasta" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(456), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(457), "Groenten" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(460), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(461), "Fruit" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8538), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8541), "Peperoni" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8547), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8548), "Hawai" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8551), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8552), "Macaroni" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8555), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8556), "Spaghetti" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8559), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8560), "Komkommer" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8602), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8603), "Tomaat" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8607), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8608), "Appel" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8612), new DateTime(2021, 10, 3, 17, 17, 9, 266, DateTimeKind.Utc).AddTicks(8613), "Peer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
