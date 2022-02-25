using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystemWeb.Migrations
{
    public partial class AddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ticketStatus",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ticketStatus",
                table: "Tickets");
        }
    }
}
