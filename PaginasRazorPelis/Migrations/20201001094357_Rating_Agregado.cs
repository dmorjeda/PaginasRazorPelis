using Microsoft.EntityFrameworkCore.Migrations;

namespace PaginasRazorPelis.Migrations
{
    public partial class Rating_Agregado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Pelicula",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Pelicula");
        }
    }
}
