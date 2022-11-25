using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDigitalAPI.Migrations
{
    public partial class updateDatabaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaOperacao");

            migrationBuilder.DropTable(
                name: "Orcamentos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Planejamentos");

            migrationBuilder.DropColumn(
                name: "IsCumprido",
                table: "Objetivos");

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Objetivos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SituacaoObjetivo",
                table: "Objetivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Objetivos_ContaId",
                table: "Objetivos",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Objetivos_Contas_ContaId",
                table: "Objetivos",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objetivos_Contas_ContaId",
                table: "Objetivos");

            migrationBuilder.DropIndex(
                name: "IX_Objetivos_ContaId",
                table: "Objetivos");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Objetivos");

            migrationBuilder.DropColumn(
                name: "SituacaoObjetivo",
                table: "Objetivos");

            migrationBuilder.AddColumn<bool>(
                name: "IsCumprido",
                table: "Objetivos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Planejamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    IsExcedido = table.Column<bool>(type: "bit", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPlanejado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planejamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planejamentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanejamentoId = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Planejamentos_PlanejamentoId",
                        column: x => x.PlanejamentoId,
                        principalTable: "Planejamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoriaOperacao",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    OperacoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaOperacao", x => new { x.CategoriasId, x.OperacoesId });
                    table.ForeignKey(
                        name: "FK_CategoriaOperacao_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaOperacao_Operacoes_OperacoesId",
                        column: x => x.OperacoesId,
                        principalTable: "Operacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orcamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ValorPlanejado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamentos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaOperacao_OperacoesId",
                table: "CategoriaOperacao",
                column: "OperacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_PlanejamentoId",
                table: "Categorias",
                column: "PlanejamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_CategoriaId",
                table: "Orcamentos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Planejamentos_UsuarioId",
                table: "Planejamentos",
                column: "UsuarioId");
        }
    }
}
