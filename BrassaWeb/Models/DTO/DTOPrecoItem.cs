using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassaWeb.Models.DTO
{
    public class DTOPrecoItem
    {
        public int IdBrasseiro { get; set; }
        public int IdItemVenda { get; set; }
        public int IdRecipiente { get; set; }
        public decimal QuantidadeVenda { get; set; }
        public decimal VolumeRecipiente { get; set; }
        public decimal PrecoRecipiente { get; set; }
        public decimal PrecoReceita { get; set; }
        public decimal PrecoCompleto { get; set; }
    }
}
