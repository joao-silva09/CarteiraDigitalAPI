using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDigitalAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operacoes_Usuarios_UsuarioId",
                table: "Operacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_Categorias_CategoriaId",
                table: "orcamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orcamentos",
                table: "orcamentos");

            migrationBuilder.RenameTable(
                name: "orcamentos",
                newName: "Orcamentos");

            migrationBuilder.RenameIndex(
                name: "IX_orcamentos_CategoriaId",
                table: "Orcamentos",
                newName: "IX_Orcamentos_CategoriaId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Operacoes",
                newName: "ContaId");

            migrationBuilder.RenameIndex(
                name: "IX_Operacoes_UsuarioId",
                table: "Operacoes",
                newName: "IX_Operacoes_ContaId");

            migrationBuilder.AddColumn<bool>(
                name: "IsGasto",
                table: "Dividas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orcamentos",
                table: "Orcamentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operacoes_Contas_ContaId",
                table: "Operacoes",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Categorias_CategoriaId",
                table: "Orcamentos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operacoes_Contas_ContaId",
                table: "Operacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Categorias_CategoriaId",
                table: "Orcamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orcamentos",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "IsGasto",
                table: "Dividas");

            migrationBuilder.RenameTable(
                name: "Orcamentos",
                newName: "orcamentos");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamentos_CategoriaId",
                table: "orcamentos",
                newName: "IX_orcamentos_CategoriaId");

            migrationBuilder.RenameColumn(
                name: "ContaId",
                table: "Operacoes",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Operacoes_ContaId",
                table: "Operacoes",
                newName: "IX_Operacoes_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orcamentos",
                table: "orcamentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operacoes_Usuarios_UsuarioId",
                table: "Operacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_Categorias_CategoriaId",
                table: "orcamentos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
