using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDigitalAPI.Migrations
{
    public partial class AddContaInDividasPagas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Dividas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dividas_ContaId",
                table: "Dividas",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dividas_Contas_ContaId",
                table: "Dividas",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dividas_Contas_ContaId",
                table: "Dividas");

            migrationBuilder.DropIndex(
                name: "IX_Dividas_ContaId",
                table: "Dividas");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Dividas");
        }
    }
}
