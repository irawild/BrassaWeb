using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Models
{
    public class EstiloCerveja
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Familia { get; set; }
        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }
        public string Caracteristicas { get; set; }
        public Nullable<decimal> GravidadeOriginalMinima { get; set; }
        public Nullable<decimal> GravidadeOriginalMaxima { get; set; }
        public Nullable<decimal> GravidadeFinalMinima { get; set; }
        public Nullable<decimal> GravidadeFinalMaxima { get; set; }
        public Nullable<decimal> CorMinima { get; set; }
        public Nullable<decimal> CorMaxima { get; set; }
        public Nullable<decimal> IBUMinimo { get; set; }
        public Nullable<decimal> IBUMaximo { get; set; }
        public Nullable<decimal> ABVMinimo { get; set; }
        public Nullable<decimal> ABVMaximo { get; set; }
    }
}
