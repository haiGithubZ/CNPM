using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jhipster.Infrastructure.Migrations
{
    public partial class updatelistShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "ShoppingCartItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProductPrice",
                table: "ShoppingCartItems",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SportName",
                table: "ShoppingCartItems",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "SportName",
                table: "ShoppingCartItems");
        }
    }
}
