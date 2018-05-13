using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Models
{
    public class Loja
    {
        [Key]
        public int Id { get; set; }
        public Cidade Cidade { get; set; }
        public string Nome { get; set; }
    }
}
