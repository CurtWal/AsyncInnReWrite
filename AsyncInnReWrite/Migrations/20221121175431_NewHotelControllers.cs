using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncInnReWrite.Migrations
{
    /// <inheritdoc />
    public partial class NewHotelControllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmenitiesID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_AmenityRoomAmenities_RoomAmenities_Amenity",
                        column: x => x.Amenity,
                        principalTable: "RoomAmenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenityRoomAmenities_Room Amenities",
                table: "AmenityRoomAmenities",
                column: "Room Amenities");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "RoomAmenities",
                column: "RoomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenityRoomAmenities");

            migrationBuilder.DropTable(
                name: "RoomAmenities");
        }
    }
}
