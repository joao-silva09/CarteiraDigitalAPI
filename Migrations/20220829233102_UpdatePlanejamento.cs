using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDigitalAPI.Migrations
{
    public partial class UpdatePlanejamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Planejamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Planejamentos_UsuarioId",
                table: "Planejamentos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planejamentos_Usuarios_UsuarioId",
                table: "Planejamentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planejamentos_Usuarios_UsuarioId",
                table: "Planejamentos");

            migrationBuilder.DropIndex(
                name: "IX_Planejamentos_UsuarioId",
                table: "Planejamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Planejamentos");
        }
    }
}
