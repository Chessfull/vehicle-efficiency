using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleEfficiencyAcd.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ActiveHours = table.Column<double>(type: "float", nullable: false),
                    MaintenanceHours = table.Column<double>(type: "float", nullable: false),
                    Week = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleUsages_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ModifiedDate", "Name", "Plate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 30, 17, 57, 23, 600, DateTimeKind.Local).AddTicks(1515), false, new DateTime(2024, 11, 30, 17, 57, 23, 601, DateTimeKind.Local).AddTicks(43), "Renault Clio", "26 KL 300" },
                    { 2, new DateTime(2024, 11, 30, 17, 57, 23, 601, DateTimeKind.Local).AddTicks(754), false, new DateTime(2024, 11, 30, 17, 57, 23, 601, DateTimeKind.Local).AddTicks(756), "Renault Clio", "26 KL 200" }
                });

            migrationBuilder.InsertData(
                table: "VehicleUsages",
                columns: new[] { "Id", "ActiveHours", "CreatedDate", "IsDeleted", "MaintenanceHours", "ModifiedDate", "VehicleId", "Week" },
                values: new object[] { 1, 2.0, new DateTime(2024, 11, 30, 17, 57, 23, 606, DateTimeKind.Local).AddTicks(821), false, 1.0, new DateTime(2024, 11, 30, 17, 57, 23, 606, DateTimeKind.Local).AddTicks(824), 1, new DateTime(2024, 11, 30, 17, 57, 23, 606, DateTimeKind.Local).AddTicks(1110) });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleUsages_VehicleId",
                table: "VehicleUsages",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleUsages");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
