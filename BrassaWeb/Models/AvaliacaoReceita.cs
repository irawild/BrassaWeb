using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Models
{
    public class AvaliacaoReceita
    {
        [Key]
        public int Id { get; set; }
        public EstoqueReceita Estoque { get; set; }
        public Degustador Degustador { get; set; }
        public int Nota { get; set; }
        public string Comentarios { get; set; }
    }
}
