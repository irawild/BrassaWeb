﻿// <auto-generated />
using BrassaWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BrassaWeb.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180511023455_ReallyAddVendaTables")]
    partial class ReallyAddVendaTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BrassaWeb.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BrassaWeb.Models.AvaliacaoBrasseiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BrasseiroId");

                    b.Property<string>("Comentarios");

                    b.Property<int?>("DegustadorId");

                    b.Property<decimal>("Nota");

                    b.HasKey("Id");

                    b.HasIndex("BrasseiroId");

                    b.HasIndex("DegustadorId");

                    b.ToTable("AvaliacaoBrasseiro");
                });

            modelBuilder.Entity("BrassaWeb.Models.AvaliacaoReceita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comentarios");

                    b.Property<int?>("DegustadorId");

                    b.Property<int?>("EstoqueId");

                    b.Property<int>("Nota");

                    b.HasKey("Id");

                    b.HasIndex("DegustadorId");

                    b.HasIndex("EstoqueId");

                    b.ToTable("AvaliacaoReceita");
                });

            modelBuilder.Entity("BrassaWeb.Models.Brasseiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CidadeId");

                    b.Property<string>("Marca");

                    b.Property<string>("Nome");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Brasseiro");
                });

            modelBuilder.Entity("BrassaWeb.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EstadoId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("BrassaWeb.Models.Cupom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<int?>("BrasseiroId");

                    b.Property<string>("Codigo");

                    b.Property<decimal>("Percentual");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("BrasseiroId");

                    b.ToTable("Cupom");
                });

            modelBuilder.Entity("BrassaWeb.Models.CupomDegustador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CupomId");

                    b.Property<int?>("DegustadorId");

                    b.Property<bool>("Usado");

                    b.HasKey("Id");

                    b.HasIndex("CupomId");

                    b.HasIndex("DegustadorId");

                    b.ToTable("CupomDegustador");
                });

            modelBuilder.Entity("BrassaWeb.Models.Degustador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CidadeId");

                    b.Property<int>("Idade");

                    b.Property<string>("Nome");

                    b.Property<string>("Sexo");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Degustador");
                });

            modelBuilder.Entity("BrassaWeb.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<int?>("PaisId");

                    b.Property<string>("Sigla");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("BrassaWeb.Models.EstiloCerveja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("ABVMaximo");

                    b.Property<decimal?>("ABVMinimo");

                    b.Property<string>("Caracteristicas");

                    b.Property<decimal?>("CorMaxima");

                    b.Property<decimal?>("CorMinima");

                    b.Property<string>("Familia")
                        .IsRequired();

                    b.Property<decimal?>("GravidadeFinalMaxima");

                    b.Property<decimal?>("GravidadeFinalMinima");

                    b.Property<decimal?>("GravidadeOriginalMaxima");

                    b.Property<decimal?>("GravidadeOriginalMinima");

                    b.Property<decimal?>("IBUMaximo");

                    b.Property<decimal?>("IBUMinimo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("EstiloCerveja");
                });

            modelBuilder.Entity("BrassaWeb.Models.EstoqueReceita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrasseiroId");

                    b.Property<decimal>("PrecoLitro");

                    b.Property<decimal>("Quantidade");

                    b.Property<int>("ReceitaId");

                    b.HasKey("Id");

                    b.HasIndex("BrasseiroId");

                    b.HasIndex("ReceitaId");

                    b.ToTable("EstoqueReceita");
                });

            modelBuilder.Entity("BrassaWeb.Models.EstoqueRecipiente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Quantidade");

                    b.Property<int?>("RecipienteId");

                    b.Property<decimal>("ValorUnidade");

                    b.HasKey("Id");

                    b.HasIndex("RecipienteId");

                    b.ToTable("EstoqueRecipiente");
                });

            modelBuilder.Entity("BrassaWeb.Models.HistoricoEstoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataHora");

                    b.Property<int>("EstoqueId");

                    b.Property<decimal>("Quantidade");

                    b.Property<byte>("TipoMovimento");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId");

                    b.ToTable("HistoricoEstoque");
                });

            modelBuilder.Entity("BrassaWeb.Models.HistoricoEstoqueRecipiente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataHora");

                    b.Property<int>("EstoqueId");

                    b.Property<decimal>("Quantidade");

                    b.Property<byte>("TipoMovimento");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId");

                    b.ToTable("HistoricoEstoqueRecipiente");
                });

            modelBuilder.Entity("BrassaWeb.Models.ItemVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CupomId");

                    b.Property<decimal>("PercentualBrassa");

                    b.Property<decimal>("QuantidadeReceita");

                    b.Property<int?>("QuantidadeRecipienteId");

                    b.Property<int?>("ReceitaId");

                    b.Property<decimal>("ValorAPagar");

                    b.Property<decimal>("ValorBrassa");

                    b.Property<decimal>("ValorReceita");

                    b.Property<decimal>("ValorRecipiente");

                    b.Property<decimal>("ValorVenda");

                    b.Property<int?>("VendaId");

                    b.HasKey("Id");

                    b.HasIndex("CupomId");

                    b.HasIndex("QuantidadeRecipienteId");

                    b.HasIndex("ReceitaId");

                    b.HasIndex("VendaId");

                    b.ToTable("ItemVenda");
                });

            modelBuilder.Entity("BrassaWeb.Models.Loja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CidadeId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Loja");
                });

            modelBuilder.Entity("BrassaWeb.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Autenticacao");

                    b.Property<Guid>("CodigoInterno");

                    b.Property<DateTime>("Data");

                    b.Property<bool>("Estornado");

                    b.Property<int?>("VendaId");

                    b.HasKey("Id");

                    b.HasIndex("VendaId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("BrassaWeb.Models.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("BrassaWeb.Models.Producao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrasseiroId");

                    b.Property<DateTime>("DataDisponibilidade");

                    b.Property<DateTime>("DataEnvase");

                    b.Property<DateTime>("DataInicio");

                    b.Property<int?>("ReceitaId");

                    b.Property<decimal>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("BrasseiroId");

                    b.HasIndex("ReceitaId");

                    b.ToTable("Producao");
                });

            modelBuilder.Entity("BrassaWeb.Models.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("ABV");

                    b.Property<decimal?>("Cor");

                    b.Property<string>("Descricao");

                    b.Property<int?>("EstiloId");

                    b.Property<decimal?>("GravidadeFinal");

                    b.Property<decimal?>("GravidadeOriginal");

                    b.Property<decimal?>("IBU");

                    b.HasKey("Id");

                    b.HasIndex("EstiloId");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("BrassaWeb.Models.Recipiente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tipo");

                    b.Property<decimal>("Volume");

                    b.HasKey("Id");

                    b.ToTable("Recipiente");
                });

            modelBuilder.Entity("BrassaWeb.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BrasseiroId");

                    b.Property<DateTime>("DataPedido");

                    b.Property<int?>("DegustadorId");

                    b.Property<string>("Situacao");

                    b.Property<decimal>("ValorTotalAPagar");

                    b.HasKey("Id");

                    b.HasIndex("BrasseiroId");

                    b.HasIndex("DegustadorId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BrassaWeb.Models.AvaliacaoBrasseiro", b =>
                {
                    b.HasOne("BrassaWeb.Models.Brasseiro", "Brasseiro")
                        .WithMany()
                        .HasForeignKey("BrasseiroId");

                    b.HasOne("BrassaWeb.Models.Degustador", "Degustador")
                        .WithMany()
                        .HasForeignKey("DegustadorId");
                });

            modelBuilder.Entity("BrassaWeb.Models.AvaliacaoReceita", b =>
                {
                    b.HasOne("BrassaWeb.Models.Degustador", "Degustador")
                        .WithMany()
                        .HasForeignKey("DegustadorId");

                    b.HasOne("BrassaWeb.Models.EstoqueReceita", "Estoque")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("EstoqueId");
                });

            modelBuilder.Entity("BrassaWeb.Models.Brasseiro", b =>
                {
                    b.HasOne("BrassaWeb.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");
                });

            modelBuilder.Entity("BrassaWeb.Models.Cidade", b =>
                {
                    b.HasOne("BrassaWeb.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");
                });

            modelBuilder.Entity("BrassaWeb.Models.Cupom", b =>
                {
                    b.HasOne("BrassaWeb.Models.Brasseiro", "Brasseiro")
                        .WithMany()
                        .HasForeignKey("BrasseiroId");
                });

            modelBuilder.Entity("BrassaWeb.Models.CupomDegustador", b =>
                {
                    b.HasOne("BrassaWeb.Models.Cupom", "Cupom")
                        .WithMany()
                        .HasForeignKey("CupomId");

                    b.HasOne("BrassaWeb.Models.Degustador", "Degustador")
                        .WithMany()
                        .HasForeignKey("DegustadorId");
                });

            modelBuilder.Entity("BrassaWeb.Models.Degustador", b =>
                {
                    b.HasOne("BrassaWeb.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");
                });

            modelBuilder.Entity("BrassaWeb.Models.Estado", b =>
                {
                    b.HasOne("BrassaWeb.Models.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("PaisId");
                });

            modelBuilder.Entity("BrassaWeb.Models.EstoqueReceita", b =>
                {
                    b.HasOne("BrassaWeb.Models.Brasseiro", "Brasseiro")
                        .WithMany("Estoques")
                        .HasForeignKey("BrasseiroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BrassaWeb.Models.Receita", "Receita")
                        .WithMany()
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BrassaWeb.Models.EstoqueRecipiente", b =>
                {
                    b.HasOne("BrassaWeb.Models.Recipiente", "Recipiente")
                        .WithMany("EstoqueRecipiente")
                        .HasForeignKey("RecipienteId");
                });

            modelBuilder.Entity("BrassaWeb.Models.HistoricoEstoque", b =>
                {
                    b.HasOne("BrassaWeb.Models.EstoqueReceita", "Estoque")
                        .WithMany()
                        .HasForeignKey("EstoqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BrassaWeb.Models.HistoricoEstoqueRecipiente", b =>
                {
                    b.HasOne("BrassaWeb.Models.EstoqueRecipiente", "Estoque")
                        .WithMany()
                        .HasForeignKey("EstoqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BrassaWeb.Models.ItemVenda", b =>
                {
                    b.HasOne("BrassaWeb.Models.Cupom", "Cupom")
                        .WithMany()
                        .HasForeignKey("CupomId");

                    b.HasOne("BrassaWeb.Models.Recipiente", "QuantidadeRecipiente")
                        .WithMany()
                        .HasForeignKey("QuantidadeRecipienteId");

                    b.HasOne("BrassaWeb.Models.Receita", "Receita")
                        .WithMany()
                        .HasForeignKey("ReceitaId");

                    b.HasOne("BrassaWeb.Models.Venda", "Venda")
                        .WithMany("ItensVenda")
                        .HasForeignKey("VendaId");
                });

            modelBuilder.Entity("BrassaWeb.Models.Loja", b =>
                {
                    b.HasOne("BrassaWeb.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");
                });

            modelBuilder.Entity("BrassaWeb.Models.Pagamento", b =>
                {
                    b.HasOne("BrassaWeb.Models.Venda", "Venda")
                        .WithMany()
                        .HasForeignKey("VendaId");
                });

            modelBuilder.Entity("BrassaWeb.Models.Producao", b =>
                {
                    b.HasOne("BrassaWeb.Models.Brasseiro", "Brasseiro")
                        .WithMany("Producoes")
                        .HasForeignKey("BrasseiroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BrassaWeb.Models.Receita", "Receita")
                        .WithMany()
                        .HasForeignKey("ReceitaId");
                });

            modelBuilder.Entity("BrassaWeb.Models.Receita", b =>
                {
                    b.HasOne("BrassaWeb.Models.EstiloCerveja", "Estilo")
                        .WithMany()
                        .HasForeignKey("EstiloId");
                });

            modelBuilder.Entity("BrassaWeb.Models.Venda", b =>
                {
                    b.HasOne("BrassaWeb.Models.Brasseiro", "Brasseiro")
                        .WithMany()
                        .HasForeignKey("BrasseiroId");

                    b.HasOne("BrassaWeb.Models.Degustador", "Degustador")
                        .WithMany()
                        .HasForeignKey("DegustadorId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BrassaWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BrassaWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BrassaWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BrassaWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
