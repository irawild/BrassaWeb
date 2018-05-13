using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrassaWeb.Data.Migrations
{
    public partial class EstoqueProducao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstoqueProducao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProducaoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueProducao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstoqueProducao_Producao_ProducaoId",
                        column: x => x.ProducaoId,
                        principalTable: "Producao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoEstoque",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataHora = table.Column<DateTime>(nullable: false),
                    ProducaoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<decimal>(nullable: false),
                    TipoMovimento = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoEstoque_Producao_ProducaoId",
                        column: x => x.ProducaoId,
                        principalTable: "Producao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueProducao_ProducaoId",
                table: "EstoqueProducao",
                column: "ProducaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstoque_ProducaoId",
                table: "HistoricoEstoque",
                column: "ProducaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstoqueProducao");

            migrationBuilder.DropTable(
                name: "HistoricoEstoque");
        }
    }
}
