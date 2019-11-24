using Microsoft.EntityFrameworkCore.Migrations;

namespace Write.Migrations
{
    public partial class TotalRaised : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalRaised",
                table: "Barbecues",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRaised",
                table: "Barbecues");
        }
    }
}
