﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coreHotelRoomBookingAdminPortal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelName = table.Column<string>(nullable: true),
                    HotelAddress = table.Column<string>(nullable: true),
                    HotelContactNumber = table.Column<long>(nullable: false),
                    HotelCountry = table.Column<string>(nullable: true),
                    HotelCity = table.Column<string>(nullable: true),
                    HotelState = table.Column<string>(nullable: true),
                    HotelDistrict = table.Column<string>(nullable: true),
                    HotelEmailId = table.Column<string>(nullable: true),
                    HotelRating = table.Column<string>(nullable: true),
                    HotelImage = table.Column<string>(nullable: true),
                    HotelDescription = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false),
                    HotelTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomType = table.Column<string>(nullable: true),
                    RoomPrice = table.Column<int>(nullable: false),
                    RoomDescription = table.Column<string>(nullable: true),
                    RoomImage = table.Column<string>(nullable: true),
                    HotelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelTypes",
                columns: table => new
                {
                    HotelTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelTypeName = table.Column<string>(nullable: true),
                    HotelTypeDescription = table.Column<string>(nullable: true),
                    HotelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelTypes", x => x.HotelTypeId);
                    table.ForeignKey(
                        name: "FK_HotelTypes_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomFacilities",
                columns: table => new
                {
                    RoomFacilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Wifi = table.Column<bool>(nullable: false),
                    AirConditioner = table.Column<bool>(nullable: false),
                    Refrigerator = table.Column<bool>(nullable: false),
                    RoomFacilityDescription = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFacilities", x => x.RoomFacilityId);
                    table.ForeignKey(
                        name: "FK_RoomFacilities_HotelRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelId",
                table: "HotelRooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelTypes_HotelId",
                table: "HotelTypes",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFacilities_RoomId",
                table: "RoomFacilities",
                column: "RoomId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelTypes");

            migrationBuilder.DropTable(
                name: "RoomFacilities");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
