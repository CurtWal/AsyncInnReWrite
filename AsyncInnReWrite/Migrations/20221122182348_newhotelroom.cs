using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsyncInnReWrite.Migrations
{
    /// <inheritdoc />
    public partial class newhotelroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "Id", "HotelID", "PetFriendly", "Rate", "RoomID", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 1, false, 80.0m, 1, 105 },
                    { 2, 2, true, 120.0m, 2, 237 },
                    { 3, 3, true, 40.0m, 3, 56 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
