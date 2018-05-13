using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrassaWeb.Data.Migrations
{
    public partial class AlteracaoNomeEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoEstoque_Producao_ProducaoId",
                table: "HistoricoEstoque");

            migrationBuilder.DropTable(
                name: "EstoqueProducao");

            migrationBuilder.RenameColumn(
                name: "ProducaoId",
                table: "HistoricoEstoque",
                newName: "EstoqueId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricoEstoque_ProducaoId",
                table: "HistoricoEstoque",
                newName: "IX_HistoricoEstoque_EstoqueId");

            migrationBuilder.AddColumn<int>(
                name: "BrasseiroId",
                table: "Producao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstoqueReceita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrasseiroId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<decimal>(nullable: false),
                    ReceitaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueReceita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstoqueReceita_Brasseiro_BrasseiroId",
                        column: x => x.BrasseiroId,
                        principalTable: "Brasseiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstoqueReceita_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producao_BrasseiroId",
                table: "Producao",
                column: "BrasseiroId");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueReceita_BrasseiroId",
                table: "EstoqueReceita",
                column: "BrasseiroId");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueReceita_ReceitaId",
                table: "EstoqueReceita",
                column: "ReceitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoEstoque_EstoqueReceita_EstoqueId",
                table: "HistoricoEstoque",
                column: "EstoqueId",
                principalTable: "EstoqueReceita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producao_Brasseiro_BrasseiroId",
                table: "Producao",
                column: "BrasseiroId",
                principalTable: "Brasseiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoEstoque_EstoqueReceita_EstoqueId",
                table: "HistoricoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Producao_Brasseiro_BrasseiroId",
                table: "Producao");

            migrationBuilder.DropTable(
                name: "EstoqueReceita");

            migrationBuilder.DropIndex(
                name: "IX_Producao_BrasseiroId",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "BrasseiroId",
                table: "Producao");

            migrationBuilder.RenameColumn(
                name: "EstoqueId",
                table: "HistoricoEstoque",
                newName: "ProducaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricoEstoque_EstoqueId",
                table: "HistoricoEstoque",
                newName: "IX_HistoricoEstoque_ProducaoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueProducao_ProducaoId",
                table: "EstoqueProducao",
                column: "ProducaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoEstoque_Producao_ProducaoId",
                table: "HistoricoEstoque",
                column: "ProducaoId",
                principalTable: "Producao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
