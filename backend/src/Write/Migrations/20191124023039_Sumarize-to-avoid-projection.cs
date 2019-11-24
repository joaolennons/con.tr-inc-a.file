using Microsoft.EntityFrameworkCore.Migrations;

namespace Write.Migrations
{
    public partial class Sumarizetoavoidprojection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Barbecues",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalParticipants",
                table: "Barbecues",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Barbecues");

            migrationBuilder.DropColumn(
                name: "TotalParticipants",
                table: "Barbecues");
        }
    }
}
