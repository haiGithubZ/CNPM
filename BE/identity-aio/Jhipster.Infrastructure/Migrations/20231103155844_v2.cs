using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jhipster.Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Bills",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InformationDelivery",
                table: "Bills",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "InformationDelivery",
                table: "Bills");
        }
    }
}
