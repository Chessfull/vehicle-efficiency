using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleEfficiencyAcd.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleImageColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 2, 1, 21, 59, 813, DateTimeKind.Local).AddTicks(293), new DateTime(2024, 12, 2, 1, 21, 59, 813, DateTimeKind.Local).AddTicks(296) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImagePath", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 2, 1, 21, 59, 807, DateTimeKind.Local).AddTicks(4877), "/images/vehicles/clio.jpg", new DateTime(2024, 12, 2, 1, 21, 59, 808, DateTimeKind.Local).AddTicks(3795) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImagePath", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 2, 1, 21, 59, 808, DateTimeKind.Local).AddTicks(4613), "/images/vehicles/clio.jpg", new DateTime(2024, 12, 2, 1, 21, 59, 808, DateTimeKind.Local).AddTicks(4615) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Vehicles");

            migrationBuilder.UpdateData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 12, 2, 0, 12, 46, 912, DateTimeKind.Local).AddTicks(1734), new DateTime(2024, 12, 2, 0, 12, 46, 912, DateTimeKind.Local).AddTicks(1737) });

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
    }
}
