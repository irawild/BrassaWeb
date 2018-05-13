using System;
using System.ComponentModel.DataAnnotations;

namespace BrassaWeb.Models
{
	public class CupomDegustador
	{
		[Key]
		public int Id { get; set; }
		public Cupom Cupom { get; set; }
		public Degustador Degustador { get; set; }
		public bool Usado { get; set; }
    }
}
