using Microsoft.EntityFrameworkCore.Migrations;

namespace coreHotelRoomBookingAdminPortal.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelTypes_Hotels_HotelId",
                table: "HotelTypes");

            migrationBuilder.DropIndex(
                name: "IX_HotelTypes_HotelId",
                table: "HotelTypes");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelTypes");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Hotels");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelTypeId",
                table: "Hotels",
                column: "HotelTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_HotelTypes_HotelTypeId",
                table: "Hotels",
                column: "HotelTypeId",
                principalTable: "HotelTypes",
                principalColumn: "HotelTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_HotelTypes_HotelTypeId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_HotelTypeId",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Hotels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelTypes_HotelId",
                table: "HotelTypes",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelTypes_Hotels_HotelId",
                table: "HotelTypes",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
