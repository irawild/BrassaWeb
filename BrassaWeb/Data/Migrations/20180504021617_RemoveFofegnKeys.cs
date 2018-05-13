using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrassaWeb.Data.Migrations
{
    public partial class RemoveFofegnKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPais",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "IdCidade",
                table: "Degustador");

            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "Cidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPais",
                table: "Estado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCidade",
                table: "Degustador",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEstado",
                table: "Cidade",
                nullable: false,
                defaultValue: 0);
        }
    }
}
