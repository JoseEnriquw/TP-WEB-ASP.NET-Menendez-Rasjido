using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    { 
            public List<ItemCarrito> Items { get; set; }
       
    }


    public class ItemCarrito
    {
        public Articulo _articulo { get; set; }
        public int cantidad { get; set; }

        public double precioSubTotal { get; set; }
    }

}
