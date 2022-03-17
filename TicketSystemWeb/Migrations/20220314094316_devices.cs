using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystemWeb.Migrations
{
    public partial class devices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    deviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientId = table.Column<int>(type: "int", nullable: false),
                    ticketId = table.Column<int>(type: "int", nullable: false),
                    deviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deviceVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    osVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.deviceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
