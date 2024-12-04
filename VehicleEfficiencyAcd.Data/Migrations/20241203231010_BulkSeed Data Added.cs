using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleEfficiencyAcd.Data.Migrations
{
    /// <inheritdoc />
    public partial class BulkSeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActiveHours", "CreatedDate", "MaintenanceHours", "ModifiedDate" },
                values: new object[] { 102.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(247), 12.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(253) });

            migrationBuilder.InsertData(
                table: "VehicleUsages",
                columns: new[] { "Id", "ActiveHours", "CreatedDate", "IsDeleted", "MaintenanceHours", "ModifiedDate", "VehicleId", "Week" },
                values: new object[,]
                {
                    { 2, 150.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(716), false, 8.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(718), 1, "W2" },
                    { 3, 130.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(720), false, 3.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(721), 1, "W3" },
                    { 4, 160.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(723), false, 7.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(723), 1, "W4" },
                    { 5, 125.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(725), false, 5.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(725), 1, "W5" },
                    { 6, 110.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(727), false, 10.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(727), 2, "W1" },
                    { 7, 140.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(729), false, 6.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(729), 2, "W2" },
                    { 8, 168.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(731), false, 1.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(731), 2, "W3" },
                    { 9, 155.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(733), false, 4.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(733), 2, "W4" },
                    { 10, 120.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(735), false, 9.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(735), 2, "W5" }
                });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImagePath", "ModifiedDate", "Name", "Plate" },
                values: new object[] { new DateTime(2024, 12, 4, 2, 10, 10, 76, DateTimeKind.Local).AddTicks(8839), "/images/vehicles/ferrari.jpg", new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8129), "Ferrari", "26 ACD 999" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "Plate" },
                values: new object[] { new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8975), new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8976), "26 DEF 200" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "IsDeleted", "ModifiedDate", "Name", "Plate" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8956), "/images/vehicles/corolla.jpg", false, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8959), "Toyota Corolla", "34 ABC 101" },
                    { 4, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8961), "/images/vehicles/civic.jpg", false, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8961), "Honda Civic", "06 DEF 202" },
                    { 5, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8964), "/images/vehicles/focus.jpg", false, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8964), "Ford Focus", "35 GHI 303" },
                    { 6, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8965), "/images/vehicles/bmw320i.jpg", false, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8966), "BMW 320i", "07 JKL 404" },
                    { 7, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8967), "/images/vehicles/mercedesc200.jpg", false, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8967), "Mercedes C200", "16 MNO 505" },
                    { 8, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8968), "/images/vehicles/audia4.jpg", false, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8969), "Audi A4", "10 PQR 606" },
                    { 9, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8970), "/images/vehicles/golf.jpg", false, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8970), "Volkswagen Golf", "20 STU 707" },
                    { 10, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8971), "/images/vehicles/altima.jpg", false, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8971), "Nissan Altima", "26 ABC 808" },
                    { 11, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8972), "/images/vehicles/elantra.jpg", false, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8973), "Hyundai Elantra", "42 YZA 909" },
                    { 12, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8974), "/images/vehicles/cruze.jpg", false, new DateTime(2024, 12, 4, 2, 10, 10, 77, DateTimeKind.Local).AddTicks(8974), "Chevrolet Cruze", "27 BCD 111" }
                });

            migrationBuilder.InsertData(
                table: "VehicleUsages",
                columns: new[] { "Id", "ActiveHours", "CreatedDate", "IsDeleted", "MaintenanceHours", "ModifiedDate", "VehicleId", "Week" },
                values: new object[,]
                {
                    { 11, 105.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(737), false, 11.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(737), 3, "W1" },
                    { 12, 170.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(738), false, 2.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(739), 3, "W2" },
                    { 13, 150.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(740), false, 5.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(741), 3, "W3" },
                    { 14, 135.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(762), false, 8.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(762), 3, "W4" },
                    { 15, 125.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(764), false, 7.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(765), 3, "W5" },
                    { 16, 115.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(766), false, 12.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(767), 4, "W1" },
                    { 17, 145.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(768), false, 9.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(769), 4, "W2" },
                    { 18, 130.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(770), false, 6.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(770), 4, "W3" },
                    { 19, 160.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(772), false, 3.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(772), 4, "W4" },
                    { 20, 125.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(774), false, 5.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(774), 4, "W5" },
                    { 21, 120.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(776), false, 10.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(777), 5, "W1" },
                    { 22, 140.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(779), false, 7.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(779), 5, "W2" },
                    { 23, 155.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(781), false, 4.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(782), 5, "W3" },
                    { 24, 135.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(783), false, 6.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(784), 5, "W4" },
                    { 25, 165.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(785), false, 2.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(786), 5, "W5" },
                    { 26, 105.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(787), false, 13.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(788), 6, "W1" },
                    { 27, 150.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(789), false, 5.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(790), 6, "W2" },
                    { 28, 140.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(791), false, 4.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(792), 6, "W3" },
                    { 29, 135.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(803), false, 9.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(804), 6, "W4" },
                    { 30, 125.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(805), false, 7.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(806), 6, "W5" },
                    { 31, 120.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(807), false, 11.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(808), 7, "W1" },
                    { 32, 165.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(809), false, 3.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(810), 7, "W2" },
                    { 33, 145.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(811), false, 5.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(811), 7, "W3" },
                    { 34, 140.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(813), false, 8.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(813), 7, "W4" },
                    { 35, 125.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(815), false, 6.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(815), 7, "W5" },
                    { 36, 130.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(816), false, 10.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(817), 8, "W1" },
                    { 37, 155.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(818), false, 4.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(819), 8, "W2" },
                    { 38, 140.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(821), false, 7.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(821), 8, "W3" },
                    { 39, 150.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(823), false, 6.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(823), 8, "W4" },
                    { 40, 135.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(824), false, 8.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(825), 8, "W5" },
                    { 41, 120.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(826), false, 11.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(827), 9, "W1" },
                    { 42, 165.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(828), false, 3.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(829), 9, "W2" },
                    { 43, 145.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(830), false, 5.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(842), 9, "W3" },
                    { 44, 140.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(844), false, 8.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(844), 9, "W4" },
                    { 45, 125.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(846), false, 6.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(846), 9, "W5" },
                    { 46, 130.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(848), false, 7.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(848), 10, "W1" },
                    { 47, 170.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(850), false, 1.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(850), 10, "W2" },
                    { 48, 150.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(852), false, 5.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(852), 10, "W3" },
                    { 49, 140.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(854), false, 6.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(854), 10, "W4" },
                    { 50, 135.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(855), false, 8.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(856), 10, "W5" },
                    { 51, 105.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(858), false, 13.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(858), 11, "W1" },
                    { 52, 160.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(859), false, 3.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(860), 11, "W2" },
                    { 53, 140.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(861), false, 4.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(862), 11, "W3" },
                    { 54, 130.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(863), false, 6.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(864), 11, "W4" },
                    { 55, 125.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(865), false, 7.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(866), 11, "W5" },
                    { 56, 120.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(867), false, 10.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(867), 12, "W1" },
                    { 57, 145.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(869), false, 9.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(869), 12, "W2" },
                    { 58, 130.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(871), false, 6.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(871), 12, "W3" },
                    { 59, 150.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(872), false, 5.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(873), 12, "W4" },
                    { 60, 135.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(874), false, 7.0, new DateTime(2024, 12, 4, 2, 10, 10, 84, DateTimeKind.Local).AddTicks(875), 12, "W5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "VehicleUsages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActiveHours", "CreatedDate", "MaintenanceHours", "ModifiedDate" },
                values: new object[] { 2.0, new DateTime(2024, 12, 2, 1, 21, 59, 813, DateTimeKind.Local).AddTicks(293), 1.0, new DateTime(2024, 12, 2, 1, 21, 59, 813, DateTimeKind.Local).AddTicks(296) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImagePath", "ModifiedDate", "Name", "Plate" },
                values: new object[] { new DateTime(2024, 12, 2, 1, 21, 59, 807, DateTimeKind.Local).AddTicks(4877), "/images/vehicles/clio.jpg", new DateTime(2024, 12, 2, 1, 21, 59, 808, DateTimeKind.Local).AddTicks(3795), "Renault Clio", "26 KL 300" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "Plate" },
                values: new object[] { new DateTime(2024, 12, 2, 1, 21, 59, 808, DateTimeKind.Local).AddTicks(4613), new DateTime(2024, 12, 2, 1, 21, 59, 808, DateTimeKind.Local).AddTicks(4615), "26 KL 200" });
        }
    }
}
