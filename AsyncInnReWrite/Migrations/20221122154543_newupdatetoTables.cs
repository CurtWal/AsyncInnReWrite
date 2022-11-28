using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncInnReWrite.Migrations
{
    /// <inheritdoc />
    public partial class newupdatetoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_Rooms_RoomId",
                table: "Amenities");

            migrationBuilder.DropForeignKey(
                name: "FK_roomAmenities_Rooms_RoomID",
                table: "roomAmenities");

            migrationBuilder.DropTable(
                name: "AmenityRoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roomAmenities",
                table: "roomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_Amenities_RoomId",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Amenities");

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

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenitiesID",
                table: "RoomAmenities",
                column: "AmenitiesID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesID",
                table: "RoomAmenities",
                column: "AmenitiesID",
                principalTable: "Amenities",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesID",
                table: "RoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_AmenitiesID",
                table: "RoomAmenities");

            migrationBuilder.RenameTable(
                name: "RoomAmenities",
                newName: "roomAmenities");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "roomAmenities",
                newName: "IX_roomAmenities_RoomID");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_roomAmenities",
                table: "roomAmenities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AmenityRoomAmenities",
                columns: table => new
                {
                    Amenity = table.Column<int>(type: "int", nullable: false),
                    RoomAmenities = table.Column<int>(name: "Room Amenities", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityRoomAmenities", x => new { x.Amenity, x.RoomAmenities });
                    table.ForeignKey(
                        name: "FK_AmenityRoomAmenities_Amenities_Room Amenities",
                        column: x => x.RoomAmenities,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenityRoomAmenities_roomAmenities_Amenity",
                        column: x => x.Amenity,
                        principalTable: "roomAmenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_RoomId",
                table: "Amenities",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_AmenityRoomAmenities_Room Amenities",
                table: "AmenityRoomAmenities",
                column: "Room Amenities");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_Rooms_RoomId",
                table: "Amenities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_roomAmenities_Rooms_RoomID",
                table: "roomAmenities",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
