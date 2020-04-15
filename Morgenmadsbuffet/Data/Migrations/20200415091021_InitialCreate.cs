using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Morgenmadsbuffet.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Checkedin = table.Column<bool>(nullable: false),
                    AmountAdults = table.Column<int>(nullable: false),
                    AmountChildren = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => new { x.RoomNumber, x.Date });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
