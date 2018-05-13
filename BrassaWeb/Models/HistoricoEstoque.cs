using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Models
{
    public class HistoricoEstoque
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public EstoqueReceita Estoque { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        [Required]
        public decimal Quantidade { get; set; }
        [Required]
        public byte TipoMovimento { get; set; }
    }
}
