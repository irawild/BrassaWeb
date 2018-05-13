using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrassaWeb.Data.Migrations
{
    public partial class AddDemaisTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brasseiro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CidadeId = table.Column<int>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brasseiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brasseiro_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstiloCerveja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ABV = table.Column<decimal>(nullable: false),
                    Caracteristicas = table.Column<string>(nullable: true),
                    Cor = table.Column<decimal>(nullable: false),
                    GravidadeFinal = table.Column<decimal>(nullable: false),
                    GravidadeOriginal = table.Column<decimal>(nullable: false),
                    IBU = table.Column<decimal>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstiloCerveja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CidadeId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loja_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoBrasseiro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrasseiroId = table.Column<int>(nullable: true),
                    Comentarios = table.Column<string>(nullable: true),
                    DegustadorId = table.Column<int>(nullable: true),
                    Nota = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoBrasseiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoBrasseiro_Brasseiro_BrasseiroId",
                        column: x => x.BrasseiroId,
                        principalTable: "Brasseiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvaliacaoBrasseiro_Degustador_DegustadorId",
                        column: x => x.DegustadorId,
                        principalTable: "Degustador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    EstiloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_EstiloCerveja_EstiloId",
                        column: x => x.EstiloId,
                        principalTable: "EstiloCerveja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Producao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataDisponibilidade = table.Column<DateTime>(nullable: false),
                    DataEnvase = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    ReceitaId = table.Column<int>(nullable: true),
                    Volume = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producao_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoBrasseiro_BrasseiroId",
                table: "AvaliacaoBrasseiro",
                column: "BrasseiroId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoBrasseiro_DegustadorId",
                table: "AvaliacaoBrasseiro",
                column: "DegustadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoProducao_DegustadorId",
                table: "AvaliacaoProducao",
                column: "DegustadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoProducao_ReceitaId",
                table: "AvaliacaoProducao",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Brasseiro_CidadeId",
                table: "Brasseiro",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loja_CidadeId",
                table: "Loja",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Producao_ReceitaId",
                table: "Producao",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_EstiloId",
                table: "Receita",
                column: "EstiloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoBrasseiro");

            migrationBuilder.DropTable(
                name: "AvaliacaoProducao");

            migrationBuilder.DropTable(
                name: "Loja");

            migrationBuilder.DropTable(
                name: "Producao");

            migrationBuilder.DropTable(
                name: "Brasseiro");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "EstiloCerveja");
        }
    }
}
