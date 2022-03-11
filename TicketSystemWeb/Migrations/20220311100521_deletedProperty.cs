using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystemWeb.Migrations
{
    public partial class deletedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "displayOrder",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "replyId",
                table: "Tickets",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "replyId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "displayOrder",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
