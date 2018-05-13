using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrassaWeb.Models
{
    public class Recipiente
    {
        [Key]
		public int Id { get; set; }
		public string Tipo { get; set; } //Garrafa, Growler, Keg, Barril, Tonel
		public decimal Volume { get; set; }
		public ICollection<EstoqueRecipiente> EstoqueRecipiente { get; set; }
    }
}
