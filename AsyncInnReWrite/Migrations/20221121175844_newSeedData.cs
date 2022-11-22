using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsyncInnReWrite.Migrations
{
    /// <inheritdoc />
    public partial class newSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmenityRoomAmenities_RoomAmenities_Amenity",
                table: "AmenityRoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.RenameTable(
                name: "RoomAmenities",
                newName: "roomAmenities");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "roomAmenities",
                newName: "IX_roomAmenities_RoomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roomAmenities",
                table: "roomAmenities",
                column: "Id");

            migrationBuilder.InsertData(
                table: "roomAmenities",
                columns: new[] { "Id", "AmenitiesID", "RoomID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AmenityRoomAmenities_roomAmenities_Amenity",
                table: "AmenityRoomAmenities",
                column: "Amenity",
                principalTable: "roomAmenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roomAmenities_Rooms_RoomID",
                table: "roomAmenities",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmenityRoomAmenities_roomAmenities_Amenity",
                table: "AmenityRoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_roomAmenities_Rooms_RoomID",
                table: "roomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roomAmenities",
                table: "roomAmenities");

            migrationBuilder.DeleteData(
                table: "roomAmenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roomAmenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roomAmenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "roomAmenities",
                newName: "RoomAmenities");

            migrationBuilder.RenameIndex(
                name: "IX_roomAmenities_RoomID",
                table: "RoomAmenities",
                newName: "IX_RoomAmenities_RoomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AmenityRoomAmenities_RoomAmenities_Amenity",
                table: "AmenityRoomAmenities",
                column: "Amenity",
                principalTable: "RoomAmenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
