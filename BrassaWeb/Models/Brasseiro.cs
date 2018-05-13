using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Models
{
    public class Brasseiro
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cidade Cidade { get; set; }
        public string Marca { get; set; }
        public string UserId { get; set; }
        public ICollection<Producao> Producoes { get; set; }
        public ICollection<EstoqueReceita> Estoques { get; set; }
    }
}
