using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrassaWeb.Data.Migrations
{
    public partial class AlteraCamposVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Cupom_CupomId",
                table: "ItemVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Recipiente_QuantidadeRecipienteId",
                table: "ItemVenda");

            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_CupomId",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "CupomId",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "PercentualBrassa",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "ValorAPagar",
                table: "ItemVenda");

            migrationBuilder.RenameColumn(
                name: "ValorVenda",
                table: "ItemVenda",
                newName: "ValorItem");

            migrationBuilder.RenameColumn(
                name: "ValorBrassa",
                table: "ItemVenda",
                newName: "QuantidadeRecipiente");

            migrationBuilder.RenameColumn(
                name: "QuantidadeRecipienteId",
                table: "ItemVenda",
                newName: "RecipienteId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVenda_QuantidadeRecipienteId",
                table: "ItemVenda",
                newName: "IX_ItemVenda_RecipienteId");

            migrationBuilder.AddColumn<int>(
                name: "CupomId",
                table: "Venda",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentualBrassa",
                table: "Venda",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorBrassa",
                table: "Venda",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorItens",
                table: "Venda",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorParcial",
                table: "Venda",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "BrasseiroId",
                table: "EstoqueRecipiente",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_CupomId",
                table: "Venda",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueRecipiente_BrasseiroId",
                table: "EstoqueRecipiente",
                column: "BrasseiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueRecipiente_Brasseiro_BrasseiroId",
                table: "EstoqueRecipiente",
                column: "BrasseiroId",
                principalTable: "Brasseiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Recipiente_RecipienteId",
                table: "ItemVenda",
                column: "RecipienteId",
                principalTable: "Recipiente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cupom_CupomId",
                table: "Venda",
                column: "CupomId",
                principalTable: "Cupom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueRecipiente_Brasseiro_BrasseiroId",
                table: "EstoqueRecipiente");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Recipiente_RecipienteId",
                table: "ItemVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cupom_CupomId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_CupomId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_EstoqueRecipiente_BrasseiroId",
                table: "EstoqueRecipiente");

            migrationBuilder.DropColumn(
                name: "CupomId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "PercentualBrassa",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "ValorBrassa",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "ValorItens",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "ValorParcial",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "BrasseiroId",
                table: "EstoqueRecipiente");

            migrationBuilder.RenameColumn(
                name: "ValorItem",
                table: "ItemVenda",
                newName: "ValorVenda");

            migrationBuilder.RenameColumn(
                name: "RecipienteId",
                table: "ItemVenda",
                newName: "QuantidadeRecipienteId");

            migrationBuilder.RenameColumn(
                name: "QuantidadeRecipiente",
                table: "ItemVenda",
                newName: "ValorBrassa");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVenda_RecipienteId",
                table: "ItemVenda",
                newName: "IX_ItemVenda_QuantidadeRecipienteId");

            migrationBuilder.AddColumn<int>(
                name: "CupomId",
                table: "ItemVenda",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentualBrassa",
                table: "ItemVenda",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAPagar",
                table: "ItemVenda",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_CupomId",
                table: "ItemVenda",
                column: "CupomId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Cupom_CupomId",
                table: "ItemVenda",
                column: "CupomId",
                principalTable: "Cupom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Recipiente_QuantidadeRecipienteId",
                table: "ItemVenda",
                column: "QuantidadeRecipienteId",
                principalTable: "Recipiente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
