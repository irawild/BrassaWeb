using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrassaWeb.Data.Migrations
{
    public partial class CamposMinimosEMaximosEstilo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IBU",
                table: "EstiloCerveja",
                newName: "IBUMinimo");

            migrationBuilder.RenameColumn(
                name: "GravidadeOriginal",
                table: "EstiloCerveja",
                newName: "IBUMaximo");

            migrationBuilder.RenameColumn(
                name: "GravidadeFinal",
                table: "EstiloCerveja",
                newName: "GravidadeOriginalMinima");

            migrationBuilder.RenameColumn(
                name: "Cor",
                table: "EstiloCerveja",
                newName: "GravidadeOriginalMaxima");

            migrationBuilder.RenameColumn(
                name: "ABV",
                table: "EstiloCerveja",
                newName: "GravidadeFinalMinima");

            migrationBuilder.AddColumn<decimal>(
                name: "ABVMaximo",
                table: "EstiloCerveja",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ABVMinimo",
                table: "EstiloCerveja",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CorMaxima",
                table: "EstiloCerveja",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CorMinima",
                table: "EstiloCerveja",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GravidadeFinalMaxima",
                table: "EstiloCerveja",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ABVMaximo",
                table: "EstiloCerveja");

            migrationBuilder.DropColumn(
                name: "ABVMinimo",
                table: "EstiloCerveja");

            migrationBuilder.DropColumn(
                name: "CorMaxima",
                table: "EstiloCerveja");

            migrationBuilder.DropColumn(
                name: "CorMinima",
                table: "EstiloCerveja");

            migrationBuilder.DropColumn(
                name: "GravidadeFinalMaxima",
                table: "EstiloCerveja");

            migrationBuilder.RenameColumn(
                name: "IBUMinimo",
                table: "EstiloCerveja",
                newName: "IBU");

            migrationBuilder.RenameColumn(
                name: "IBUMaximo",
                table: "EstiloCerveja",
                newName: "GravidadeOriginal");

            migrationBuilder.RenameColumn(
                name: "GravidadeOriginalMinima",
                table: "EstiloCerveja",
                newName: "GravidadeFinal");

            migrationBuilder.RenameColumn(
                name: "GravidadeOriginalMaxima",
                table: "EstiloCerveja",
                newName: "Cor");

            migrationBuilder.RenameColumn(
                name: "GravidadeFinalMinima",
                table: "EstiloCerveja",
                newName: "ABV");
        }
    }
}
