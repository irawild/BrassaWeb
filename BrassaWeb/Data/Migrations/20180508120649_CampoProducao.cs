using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrassaWeb.Data.Migrations
{
    public partial class CampoProducao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ABV",
                table: "Producao",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cor",
                table: "Producao",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GravidadeFinal",
                table: "Producao",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GravidadeOriginal",
                table: "Producao",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IBU",
                table: "Producao",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ABV",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "GravidadeFinal",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "GravidadeOriginal",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "IBU",
                table: "Producao");
        }
    }
}
