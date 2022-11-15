using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDigitalAPI.Migrations
{
    public partial class AddTipoDivida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGasto",
                table: "Dividas");

            migrationBuilder.AddColumn<int>(
                name: "TipoDivida",
                table: "Dividas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDivida",
                table: "Dividas");

            migrationBuilder.AddColumn<bool>(
                name: "IsGasto",
                table: "Dividas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
