using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test2.Migrations
{
    public partial class Complete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.IdCar);
                });

            migrationBuilder.CreateTable(
                name: "Mechanic",
                columns: table => new
                {
                    IdMechanic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanic", x => x.IdMechanic);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeDict",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeDict", x => x.IdServiceType);
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    IdInspection = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdMechanic = table.Column<int>(type: "int", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.IdInspection);
                    table.ForeignKey(
                        name: "FK_Inspection_Car_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Car",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspection_Mechanic_IdMechanic",
                        column: x => x.IdMechanic,
                        principalTable: "Mechanic",
                        principalColumn: "IdMechanic",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiseTypeDict_Inspection",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false),
                    IdInspection = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiseTypeDict_Inspection", x => new { x.IdInspection, x.IdServiceType });
                    table.ForeignKey(
                        name: "FK_ServiseTypeDict_Inspection_Inspection_IdInspection",
                        column: x => x.IdInspection,
                        principalTable: "Inspection",
                        principalColumn: "IdInspection",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiseTypeDict_Inspection_ServiceTypeDict_IdServiceType",
                        column: x => x.IdServiceType,
                        principalTable: "ServiceTypeDict",
                        principalColumn: "IdServiceType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "IdCar", "Name", "ProductionYear" },
                values: new object[] { 1, "BMW", 2020 });

            migrationBuilder.InsertData(
                table: "Mechanic",
                columns: new[] { "IdMechanic", "FirstName", "LastName" },
                values: new object[] { 1, "Jon", "Doe" });

            migrationBuilder.InsertData(
                table: "ServiceTypeDict",
                columns: new[] { "IdServiceType", "Price", "ServiceType" },
                values: new object[] { 1, 100.56f, "Full" });

            migrationBuilder.InsertData(
                table: "Inspection",
                columns: new[] { "IdInspection", "Comment", "IdCar", "IdMechanic", "InspectionDate" },
                values: new object[] { 1, "ababa", 1, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ServiseTypeDict_Inspection",
                columns: new[] { "IdInspection", "IdServiceType", "Comments" },
                values: new object[] { 1, 1, "xyxyx" });

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_IdCar",
                table: "Inspection",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_IdMechanic",
                table: "Inspection",
                column: "IdMechanic");

            migrationBuilder.CreateIndex(
                name: "IX_ServiseTypeDict_Inspection_IdServiceType",
                table: "ServiseTypeDict_Inspection",
                column: "IdServiceType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiseTypeDict_Inspection");

            migrationBuilder.DropTable(
                name: "Inspection");

            migrationBuilder.DropTable(
                name: "ServiceTypeDict");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Mechanic");
        }
    }
}
