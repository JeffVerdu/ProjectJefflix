using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JefflixMVC.Migrations
{
    public partial class campo_activo_series : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Series",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Series");
        }
    }
}
