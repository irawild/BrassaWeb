using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public Pais Pais { get; set; }
    }
}
