using System;
using System.ComponentModel.DataAnnotations;

namespace BrassaWeb.Models
{
    public class Cupom
    {
        [Key]
		public int Id { get; set; }
		public string Codigo { get; set; }
		public decimal Valor { get; set; }
		public decimal Percentual { get; set; }
		public Brasseiro Brasseiro { get; set; }
		public bool Ativo { get; set; }
    }
}
