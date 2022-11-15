using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDigitalAPI.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Operacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operacoes_UsuarioId",
                table: "Operacoes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operacoes_Usuarios_UsuarioId",
                table: "Operacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operacoes_Usuarios_UsuarioId",
                table: "Operacoes");

            migrationBuilder.DropIndex(
                name: "IX_Operacoes_UsuarioId",
                table: "Operacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Operacoes");
        }
    }
}
