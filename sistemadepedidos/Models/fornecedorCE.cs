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
        [Display(Name ="Ingrese Nome")]
        public string nome { get; set; }
        [Required]
        [Display(Name = "Ingrese CNPJ")]
        public string cnpj { get; set; }
        [Required]
        [Display(Name = "Ingrese UF")]
        public string uf { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Ingrese EMAIL")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Ingrese Razão Social")]
        public string razao { get; set; }
    }
    [MetadataType(typeof(fornecedorCE))]
    public partial class fornecedor
    {
     
    }
}