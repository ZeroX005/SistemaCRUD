//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaCRUD.ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public int cod_producto { get; set; }
        public string nombre_producto { get; set; }
        public string modelo_producto { get; set; }
        public int cod_marca { get; set; }
        public int cod_proveedor { get; set; }
        public int cod_categoria { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Proveedor Proveedor { get; set; }

    }
}
