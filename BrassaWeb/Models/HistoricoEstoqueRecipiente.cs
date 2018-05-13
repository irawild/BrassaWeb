using System;
using System.ComponentModel.DataAnnotations;

namespace BrassaWeb.Models
{
	public class HistoricoEstoqueRecipiente
    {
        [Key]
        public int Id { get; set; }
        [Required]
		public EstoqueRecipiente Estoque { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        [Required]
        public decimal Quantidade { get; set; }
        [Required]
        public byte TipoMovimento { get; set; }
    }
}
