//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sistemadepedidos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pedidos
    {
        public int id { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public Nullable<int> id_produto { get; set; }
        public Nullable<int> quantidade { get; set; }
        public Nullable<int> id_fornecedor { get; set; }
        public Nullable<double> valortotal { get; set; }
    
        public virtual fornecedor fornecedor { get; set; }
        public virtual produto produto { get; set; }
    }
}
