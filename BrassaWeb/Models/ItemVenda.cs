using System;
using System.ComponentModel.DataAnnotations;

namespace BrassaWeb.Models
{
	public class ItemVenda
	{
		[Key]
		public int Id { get; set; }
		public Venda Venda { get; set; }
		public Receita Receita { get; set; }
		public decimal QuantidadeReceita { get; set; }
		public Recipiente Recipiente { get; set; }
        public decimal QuantidadeRecipiente { get; set; }
        public decimal ValorReceita { get; set; }
		public decimal ValorRecipiente { get; set; }
		public decimal ValorItem { get; set; }
    }
}
