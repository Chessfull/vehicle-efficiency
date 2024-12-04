using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleEfficiencyAcd.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleUsageChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Week",
                table: "VehicleUsages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "VehicleUsages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "Week" },
                values: new object[] { new DateTime(2024, 12, 2, 0, 12, 46, 912, DateTimeKind.Local).AddTicks(1734), new DateTime(2024, 12, 2, 0, 12, 46, 912, DateTimeKind.Local).AddTicks(1737), "W1" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 2, 0, 12, 46, 905, DateTimeKind.Local).AddTicks(9924), new DateTime(2024, 12, 2, 0, 12, 46, 907, DateTimeKind.Local).AddTicks(1032) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 2, 0, 12, 46, 907, DateTimeKind.Local).AddTicks(1800), new DateTime(2024, 12, 2, 0, 12, 46, 907, DateTimeKind.Local).AddTicks(1803) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Week",
                table: "VehicleUsages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "VehicleUsages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
    }
}
