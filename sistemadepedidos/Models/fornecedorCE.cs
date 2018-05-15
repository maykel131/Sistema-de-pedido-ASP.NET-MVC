using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistemadepedidos.Models
{
    public class fornecedorCE
    {
        [Required]
        [Display(Name ="Nome")]
        public string nome { get; set; }
        [Required]
        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }
        [Required]
        [Display(Name = "UF")]
        public string uf { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "EMAIL")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Razão Social")]
        public string razao { get; set; }
    }
    [MetadataType(typeof(fornecedorCE))]
    public partial class fornecedor
    {
     
    }
}