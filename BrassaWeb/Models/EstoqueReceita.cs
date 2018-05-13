using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrassaWeb.Models
{
	public class EstoqueReceita
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Brasseiro Brasseiro { get; set; }
        [Required]
        public Receita Receita { get; set; }
        public decimal Quantidade { get; set; }
		public decimal PrecoLitro { get; set; }
        public ICollection<AvaliacaoReceita> Avaliacoes { get; set; }
    }
}
