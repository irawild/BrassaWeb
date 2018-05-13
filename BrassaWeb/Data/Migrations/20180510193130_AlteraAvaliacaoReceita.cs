using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrassaWeb.Data.Migrations
{
    public partial class AlteraAvaliacaoReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoProducao");

            migrationBuilder.CreateTable(
                name: "AvaliacaoReceita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comentarios = table.Column<string>(nullable: true),
                    DegustadorId = table.Column<int>(nullable: true),
                    EstoqueId = table.Column<int>(nullable: true),
                    Nota = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoReceita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoReceita_Degustador_DegustadorId",
                        column: x => x.DegustadorId,
                        principalTable: "Degustador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvaliacaoReceita_EstoqueReceita_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "EstoqueReceita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoReceita_DegustadorId",
                table: "AvaliacaoReceita",
                column: "DegustadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoReceita_EstoqueId",
                table: "AvaliacaoReceita",
                column: "EstoqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoReceita");

            migrationBuilder.CreateTable(
                name: "AvaliacaoProducao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comentarios = table.Column<string>(nullable: true),
                    DegustadorId = table.Column<int>(nullable: true),
                    Nota = table.Column<decimal>(nullable: false),
                    ReceitaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoProducao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoProducao_Degustador_DegustadorId",
                        column: x => x.DegustadorId,
                        principalTable: "Degustador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvaliacaoProducao_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoProducao_DegustadorId",
                table: "AvaliacaoProducao",
                column: "DegustadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoProducao_ReceitaId",
                table: "AvaliacaoProducao",
                column: "ReceitaId");
        }
    }
}
