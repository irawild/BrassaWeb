using System;
using System.ComponentModel.DataAnnotations;

namespace BrassaWeb.Models
{
    public class Receita
    {
        [Key]
        public int Id { get; set; }
        public EstiloCerveja Estilo { get; set; }
        public string Descricao { get; set; }
        public Nullable<decimal> GravidadeOriginal { get; set; }
        public Nullable<decimal> GravidadeFinal { get; set; }
        public Nullable<decimal> IBU { get; set; }
        public Nullable<decimal> ABV { get; set; }
        public Nullable<decimal> Cor { get; set; }
    }
}
