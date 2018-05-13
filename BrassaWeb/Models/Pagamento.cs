using System;
using System.ComponentModel.DataAnnotations;

namespace BrassaWeb.Models
{
	public class Pagamento
	{
		[Key]
		public int Id { get; set; }
		public Venda Venda { get; set; }
		public DateTime Data { get; set; }
		public string Autenticacao { get; set; }
		public Guid CodigoInterno { get; set; }
		public bool Estornado { get; set; }
	}
}
