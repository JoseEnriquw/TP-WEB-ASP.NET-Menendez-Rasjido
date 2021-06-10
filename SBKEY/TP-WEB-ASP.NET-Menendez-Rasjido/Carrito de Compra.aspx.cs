using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Bussines;
using System.Data;

namespace TP_WEB_ASP.NET_Menendez_Rasjido
{
    public partial class Carrito_de_Compra : System.Web.UI.Page
    {
        public List<Articulo> carritoLista;
        public List<ItemCarrito> itemsCarrito;
        public ItemCarrito itemAux;
        public List<Carrito> compra;
        public int id;
        public bool band;
        public int contadornoti;
        protected void Page_Load(object sender, EventArgs e)
        {
            carritoLista = (List<Articulo>)Session["listaCompra"];
            itemsCarrito = (List<ItemCarrito>)Session["ListaItems"];
            if (carritoLista == null)
            {
                contadornoti = 0;
                carritoLista = new List<Articulo>();
            }
            if (itemsCarrito == null) itemsCarrito = new List<ItemCarrito>();

            if (band == false) {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if (carritoLista.Find(x => x.ID.ToString() == Request.QueryString["id"]) == null)
                    {
                        List<Articulo> listadoOriginal = (List<Articulo>)Session["listadoProducto"];
                        int aux = int.Parse(Request.QueryString["id"]);
                        carritoLista.Add(listadoOriginal.Find(x => x.ID == aux));

                        itemsCarrito.Add(new ItemCarrito() { articulo = listadoOriginal.Find(x => x.ID == aux),
                        cantidad = 1, precioSubTotal = listadoOriginal.Find(x => x.ID.ToString() == Request.QueryString["id"]).precio });
                    }
                    else
                    {
                        itemAux = new ItemCarrito();
                        
                        List<ItemCarrito> listadoOr = (List<ItemCarrito>)Session["ListaItems"];
                        int aux = int.Parse(Request.QueryString["id"]);
                        itemAux=listadoOr.Find(x => x.articulo.ID == aux);

                        int cant = (itemAux.cantidad);
                        cant++;
                        decimal subt = itemAux.articulo.precio;
                        subt = cant * subt;
                        var replaceItem = new ItemCarrito { articulo = itemAux.articulo, cantidad = cant, precioSubTotal = subt };

                        var element = itemsCarrito.FirstOrDefault(i => i.articulo.ID == replaceItem.articulo.ID);

                        itemsCarrito.Remove(element);
                        itemsCarrito.Add(replaceItem);
                    }
                }
                band = false;
                //Repeater
                repetidorCompra.DataSource = itemsCarrito;
                repetidorCompra.DataBind();
            }
            }
            Session.Add("listaCompra", carritoLista);
            Session.Add("listaItems", itemsCarrito);

            band = false;

            compra = (List<Carrito>)Session["precompra"];
            compra = new List<Carrito>();
            compra.Clear();

            decimal prodt = 0;

            foreach (ItemCarrito item in itemsCarrito)
            {
                prodt = prodt + (item.precioSubTotal);
            }

            compra.Add(new Carrito() { totalproductos = prodt, adicional = 800, total = prodt + 800 });
            Session.Add("precompra", compra);

            repetidorData.DataSource = compra;
            repetidorData.DataBind();

            int cont= 0;
            foreach(ItemCarrito item in itemsCarrito)
            {
                ((TextBox)repetidorCompra.Items[cont].FindControl("txtCantidad")).Text = item.cantidad.ToString();
                cont++;
            }

            contadornoti=itemsCarrito.Count;
        }

        public int noticontador()
        {
            return contadornoti;
        }

        protected void btnEliminar3_Click(object sender, EventArgs e)
        {
            var argument = ((ImageButton)sender).CommandArgument;
            List<ItemCarrito> it= (List<ItemCarrito>)Session["listaItems"];
            int aux = int.Parse(argument);
            var elem = itemsCarrito.FirstOrDefault(i => i.articulo.ID == aux);

            itemsCarrito.Remove(elem);
            Session.Add("listaItems", itemsCarrito);
            repetidorCompra.DataSource = null;
            repetidorCompra.DataSource = itemsCarrito;
            repetidorCompra.DataBind();
            Page_Load(sender,e);
        }

        protected void cantidadresta(object sender, EventArgs e)
        {
            itemAux = new ItemCarrito();

            var argument = ((ImageButton)sender).CommandArgument;
            int aux = int.Parse(argument);

            List<ItemCarrito> listadoOr = (List<ItemCarrito>)Session["ListaItems"];
            itemAux = listadoOr.Find(x => x.articulo.ID == aux);

            int cantN = itemAux.cantidad;
            if (cantN == 1)
            {
                var elem = itemsCarrito.FirstOrDefault(i => i.articulo.ID == aux);
                itemsCarrito.Remove(elem);
                Session.Add("listaItems", itemsCarrito);
                repetidorCompra.DataSource = null;
                repetidorCompra.DataSource = itemsCarrito;
                repetidorCompra.DataBind();
                Page_Load(sender, e);
                return;
            }
            else
            {
                cantN--;
            }
            decimal subt = itemAux.articulo.precio;
            subt = cantN * subt;

            var replaceItem = new ItemCarrito { articulo = itemAux.articulo, cantidad = cantN, precioSubTotal = subt };

            var element = itemsCarrito.FirstOrDefault(i => i.articulo.ID == replaceItem.articulo.ID);

            itemsCarrito.Remove(element);
            itemsCarrito.Add(replaceItem);
            Page_Load(sender, e);
        }

        protected void cantidadsuma(object sender, EventArgs e)
        {
            itemAux=new ItemCarrito();

            var argument = ((ImageButton)sender).CommandArgument;
            int aux = int.Parse(argument);

            List<ItemCarrito> listadoOr = (List<ItemCarrito>)Session["ListaItems"];
            itemAux = listadoOr.Find(x => x.articulo.ID == aux);
            
            int cantN = itemAux.cantidad;
            if (cantN == 1)
            {
                cantN = 2;
            }
            else
            {
                cantN++;
            }
            decimal subt = itemAux.articulo.precio;
            subt = cantN * subt;

            var replaceItem = new ItemCarrito { articulo = itemAux.articulo, cantidad = cantN, precioSubTotal =  subt };

            var element = itemsCarrito.FirstOrDefault(i => i.articulo.ID == replaceItem.articulo.ID);
              
            itemsCarrito.Remove(element);
            itemsCarrito.Add(replaceItem);
            Page_Load(sender, e);
        }


    }
}