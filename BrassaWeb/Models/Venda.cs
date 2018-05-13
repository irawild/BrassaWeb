using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrassaWeb.Models
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }
		public string Situacao { get; set; } //1 - Pedido, 2 - Reserva, 3 - Pago, 4 - Aguardando, 5 - Entregue, 6 - Cancelado
		public DateTime DataPedido { get; set; }
		public Degustador Degustador { get; set; }
		public Brasseiro Brasseiro { get; set; }
		public ICollection<ItemVenda> ItensVenda { get; set; }
        public decimal ValorItens { get; set; }
        public Cupom Cupom { get; set; }
        public decimal ValorParcial { get; set; }
        public decimal PercentualBrassa { get; set; }
        public decimal ValorBrassa { get; set; }
        public decimal ValorTotalAPagar { get; set; }

    }
}
