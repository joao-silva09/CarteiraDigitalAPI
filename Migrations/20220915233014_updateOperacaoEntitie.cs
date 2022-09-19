using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDigitalAPI.Migrations
{
    public partial class updateOperacaoEntitie : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Operacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Operacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orcamentos",
                table: "Orcamentos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Operacoes_ContaId",
                table: "Operacoes",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operacoes_Contas_ContaId",
                table: "Operacoes",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operacoes_Usuarios_UsuarioId",
                table: "Operacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Operacoes_Usuarios_UsuarioId",
                table: "Operacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Categorias_CategoriaId",
                table: "Orcamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orcamentos",
                table: "Orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_Operacoes_ContaId",
                table: "Operacoes");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Operacoes");

            migrationBuilder.RenameTable(
                name: "Orcamentos",
                newName: "orcamentos");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamentos_CategoriaId",
                table: "orcamentos",
                newName: "IX_orcamentos_CategoriaId");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Operacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
