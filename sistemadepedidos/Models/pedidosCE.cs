using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistemadepedidos.Models
{
    public class pedidosCE
    {
        public int id { get; set; }
      
        public Nullable<System.DateTime> data { get; set; }
        [Required]
        public Nullable<int> id_produto { get; set; }
        [Required]
        public Nullable<int> quantidade { get; set; }
        [Required]
        public Nullable<int> id_fornecedor { get; set; }

        [DataType(DataType.Currency)]
        public Nullable<double> valortotal { get; set; }

        public virtual fornecedor fornecedor { get; set; }
        public virtual produto produto { get; set; }
    }
    [MetadataType(typeof(pedidosCE))]
    public partial class pedidos
    {
    }
}