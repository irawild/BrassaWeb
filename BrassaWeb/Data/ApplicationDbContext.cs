using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BrassaWeb.Models;
using DataRepository.Data;

namespace BrassaWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDataRepositoryContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Degustador> Degustador { get; set; }
        public DbSet<EstiloCerveja> EstiloCerveja { get; set; }
        public DbSet<Brasseiro> Brasseiro { get; set; }
        public DbSet<Loja> Loja { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<Producao> Producao { get; set; }
        public DbSet<AvaliacaoBrasseiro> AvaliacaoBrasseiro { get; set; }
        public DbSet<AvaliacaoReceita> AvaliacaoReceita { get; set; }
        public DbSet<EstoqueReceita> EstoqueReceita { get; set; }
        public DbSet<HistoricoEstoque> HistoricoEstoque { get; set; }
		public DbSet<Cupom> Cupom { get; set; }
		public DbSet<CupomDegustador> CupomDegustador { get; set; }
		public DbSet<EstoqueRecipiente> EstoqueRecipiente { get; set; }
		public DbSet<HistoricoEstoqueRecipiente> HistoricoEstoqueRecipiente { get; set; }
		public DbSet<ItemVenda> ItemVenda { get; set; }
		public DbSet<Pagamento> Pagamento { get; set; }
		public DbSet<Recipiente> Recipiente { get; set; }
		public DbSet<Venda> Venda { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
