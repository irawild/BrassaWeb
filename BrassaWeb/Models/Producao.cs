using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Models
{
    public class Producao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Brasseiro Brasseiro { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataEnvase { get; set; }
        public DateTime DataDisponibilidade { get; set; }
        public Receita Receita { get; set; }
        public decimal Volume { get; set; }
    }
}
