using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistemadepedidos.Models
{
    public class produtoCE
    {
        public int id { get; set; }
        [Required]
        public string descripcion { get; set; }
       
        public Nullable<System.DateTime> data { get; set; }

        [Required(ErrorMessage = "Deve ingresar 3 decimais ")]
        [DataType(DataType.Currency)]
        public Nullable<double> valor { get; set; }
    }
    [MetadataType(typeof(produtoCE))]
    public partial class produto
    {

    }
}