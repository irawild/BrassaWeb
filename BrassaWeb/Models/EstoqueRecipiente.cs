using System;
using System.ComponentModel.DataAnnotations;

namespace BrassaWeb.Models
{
    public class EstoqueRecipiente
    {
        [Key]
		public int Id { get; set; }
        public Brasseiro Brasseiro { get; set; }
		public Recipiente Recipiente { get; set; }
		public decimal Quantidade { get; set; }
		public decimal ValorUnidade { get; set; }
    }
}
