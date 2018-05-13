using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrassaWeb.Data.Migrations
{
    public partial class ReallyAddVendaTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cupom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    BrasseiroId = table.Column<int>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Percentual = table.Column<decimal>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cupom_Brasseiro_BrasseiroId",
                        column: x => x.BrasseiroId,
                        principalTable: "Brasseiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipiente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true),
                    Volume = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipiente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrasseiroId = table.Column<int>(nullable: true),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    DegustadorId = table.Column<int>(nullable: true),
                    Situacao = table.Column<string>(nullable: true),
                    ValorTotalAPagar = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Brasseiro_BrasseiroId",
                        column: x => x.BrasseiroId,
                        principalTable: "Brasseiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venda_Degustador_DegustadorId",
                        column: x => x.DegustadorId,
                        principalTable: "Degustador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CupomDegustador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CupomId = table.Column<int>(nullable: true),
                    DegustadorId = table.Column<int>(nullable: true),
                    Usado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CupomDegustador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CupomDegustador_Cupom_CupomId",
                        column: x => x.CupomId,
                        principalTable: "Cupom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CupomDegustador_Degustador_DegustadorId",
                        column: x => x.DegustadorId,
                        principalTable: "Degustador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstoqueRecipiente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<decimal>(nullable: false),
                    RecipienteId = table.Column<int>(nullable: true),
                    ValorUnidade = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueRecipiente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstoqueRecipiente_Recipiente_RecipienteId",
                        column: x => x.RecipienteId,
                        principalTable: "Recipiente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CupomId = table.Column<int>(nullable: true),
                    PercentualBrassa = table.Column<decimal>(nullable: false),
                    QuantidadeReceita = table.Column<decimal>(nullable: false),
                    QuantidadeRecipienteId = table.Column<int>(nullable: true),
                    ReceitaId = table.Column<int>(nullable: true),
                    ValorAPagar = table.Column<decimal>(nullable: false),
                    ValorBrassa = table.Column<decimal>(nullable: false),
                    ValorReceita = table.Column<decimal>(nullable: false),
                    ValorRecipiente = table.Column<decimal>(nullable: false),
                    ValorVenda = table.Column<decimal>(nullable: false),
                    VendaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Cupom_CupomId",
                        column: x => x.CupomId,
                        principalTable: "Cupom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Recipiente_QuantidadeRecipienteId",
                        column: x => x.QuantidadeRecipienteId,
                        principalTable: "Recipiente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Autenticacao = table.Column<string>(nullable: true),
                    CodigoInterno = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Estornado = table.Column<bool>(nullable: false),
                    VendaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoEstoqueRecipiente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataHora = table.Column<DateTime>(nullable: false),
                    EstoqueId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<decimal>(nullable: false),
                    TipoMovimento = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoEstoqueRecipiente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoEstoqueRecipiente_EstoqueRecipiente_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "EstoqueRecipiente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cupom_BrasseiroId",
                table: "Cupom",
                column: "BrasseiroId");

            migrationBuilder.CreateIndex(
                name: "IX_CupomDegustador_CupomId",
                table: "CupomDegustador",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_CupomDegustador_DegustadorId",
                table: "CupomDegustador",
                column: "DegustadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueRecipiente_RecipienteId",
                table: "EstoqueRecipiente",
                column: "RecipienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstoqueRecipiente_EstoqueId",
                table: "HistoricoEstoqueRecipiente",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_CupomId",
                table: "ItemVenda",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_QuantidadeRecipienteId",
                table: "ItemVenda",
                column: "QuantidadeRecipienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ReceitaId",
                table: "ItemVenda",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_VendaId",
                table: "ItemVenda",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_VendaId",
                table: "Pagamento",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_BrasseiroId",
                table: "Venda",
                column: "BrasseiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_DegustadorId",
                table: "Venda",
                column: "DegustadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CupomDegustador");

            migrationBuilder.DropTable(
                name: "HistoricoEstoqueRecipiente");

            migrationBuilder.DropTable(
                name: "ItemVenda");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "EstoqueRecipiente");

            migrationBuilder.DropTable(
                name: "Cupom");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Recipiente");
        }
    }
}
