using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDigitalAPI.Migrations
{
    public partial class UpdateOperacaoTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGasto",
                table: "Operacoes");

            migrationBuilder.AlterColumn<string>(
                name: "DataOperacao",
                table: "Operacoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "TipoDivida",
                table: "Operacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDivida",
                table: "Operacoes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOperacao",
                table: "Operacoes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsGasto",
                table: "Operacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
