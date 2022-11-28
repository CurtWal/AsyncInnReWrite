using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsyncInnReWrite.Migrations
{
    /// <inheritdoc />
    public partial class NewTableHotelRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Hotels_HotelID",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Rooms_RoomID",
                table: "HotelRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom");

            migrationBuilder.RenameTable(
                name: "HotelRoom",
                newName: "HotelRooms");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_RoomID",
                table: "HotelRooms",
                newName: "IX_HotelRooms_RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_HotelID",
                table: "HotelRooms",
                newName: "IX_HotelRooms_HotelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                column: "Id");

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "Id", "HotelID", "PetFriendly", "Rate", "RoomID", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 1, false, 80.0m, 1, 107 },
                    { 2, 2, true, 120.0m, 2, 239 },
                    { 3, 3, true, 40.0m, 3, 55 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Hotels_HotelID",
                table: "HotelRooms",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Rooms_RoomID",
                table: "HotelRooms",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Hotels_HotelID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Rooms_RoomID",
                table: "HotelRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "HotelRooms",
                newName: "HotelRoom");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRooms_RoomID",
                table: "HotelRoom",
                newName: "IX_HotelRoom_RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRooms_HotelID",
                table: "HotelRoom",
                newName: "IX_HotelRoom_HotelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Hotels_HotelID",
                table: "HotelRoom",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Rooms_RoomID",
                table: "HotelRoom",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
