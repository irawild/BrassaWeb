using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Estado> Estados { get; set; }
    }
}
