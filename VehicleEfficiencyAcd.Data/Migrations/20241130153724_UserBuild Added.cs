using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleEfficiencyAcd.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserBuildAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "Week" },
                values: new object[] { new DateTime(2024, 11, 30, 18, 37, 23, 756, DateTimeKind.Local).AddTicks(7281), new DateTime(2024, 11, 30, 18, 37, 23, 756, DateTimeKind.Local).AddTicks(7284), new DateTime(2024, 11, 30, 18, 37, 23, 756, DateTimeKind.Local).AddTicks(7569) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 30, 18, 37, 23, 750, DateTimeKind.Local).AddTicks(3797), new DateTime(2024, 11, 30, 18, 37, 23, 751, DateTimeKind.Local).AddTicks(4067) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 30, 18, 37, 23, 751, DateTimeKind.Local).AddTicks(7748), new DateTime(2024, 11, 30, 18, 37, 23, 751, DateTimeKind.Local).AddTicks(7751) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "Week" },
                values: new object[] { new DateTime(2024, 11, 30, 17, 57, 23, 606, DateTimeKind.Local).AddTicks(821), new DateTime(2024, 11, 30, 17, 57, 23, 606, DateTimeKind.Local).AddTicks(824), new DateTime(2024, 11, 30, 17, 57, 23, 606, DateTimeKind.Local).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 30, 17, 57, 23, 600, DateTimeKind.Local).AddTicks(1515), new DateTime(2024, 11, 30, 17, 57, 23, 601, DateTimeKind.Local).AddTicks(43) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 30, 17, 57, 23, 601, DateTimeKind.Local).AddTicks(754), new DateTime(2024, 11, 30, 17, 57, 23, 601, DateTimeKind.Local).AddTicks(756) });
        }
    }
}
