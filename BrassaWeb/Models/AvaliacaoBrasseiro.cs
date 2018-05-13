using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Models
{
    public class AvaliacaoBrasseiro
    {
        [Key]
        public int Id { get; set; }
        public Brasseiro Brasseiro { get; set; }
        public Degustador Degustador { get; set; }
        public decimal Nota { get; set; }
        public String Comentarios { get; set; }
    }
}
