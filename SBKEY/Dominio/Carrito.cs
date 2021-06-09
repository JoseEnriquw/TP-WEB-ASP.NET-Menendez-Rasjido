using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    { 
        public decimal totalproductos { get; set; }
        public decimal adicional { get; set; }
        public decimal total { get; set; }
    }


    public class ItemCarrito
    {
        public Articulo articulo { get; set; }
        public int cantidad { get; set; }
        public decimal precioSubTotal { get; set; }
    }

}
