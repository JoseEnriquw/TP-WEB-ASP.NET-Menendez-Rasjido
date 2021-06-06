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
        protected void Page_Load(object sender, EventArgs e)
        {
            carritoLista = (List<Articulo>)Session["listaCompra"];

            if (carritoLista == null) { carritoLista = new List<Articulo>();}


            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    
                    if (carritoLista.Find(x => x.ID.ToString() == Request.QueryString["id"]) == null)
                    {
                        List<Articulo> listadoOriginal = (List<Articulo>)Session["listadoProducto"];
                        carritoLista.Add(listadoOriginal.Find(x => x.ID.ToString() == Request.QueryString["id"]));
                    }
                }

                //Repeater
                repetidorCompra.DataSource = carritoLista;
                repetidorCompra.DataBind();
            }

            Session.Add("listaCompra", carritoLista);

        }
        /*
        protected void Unnamed_Click(object sender, EventArgs e)
        {
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
        }

        protected void btnEliminar2_Click(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            List<Articulo> favoritos = (List<Articulo>)Session["listaCompra"];
            Articulo elim = favoritos.Find(x => x.ID.ToString() == argument);
            favoritos.Remove(elim);
            Session.Add("listaCompra", favoritos);
            repetidor.DataSource = null;
            repetidor.DataSource = favoritos;
            repetidor.DataBind();
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            lblEjemplo.Text = "El valor es: " + ((TextBox)sender).Text;
        }

        protected void ddlCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var argument = ((DropDownList)sender);
            lblDesplegable.Text = "El DDL tiene " + ((DropDownList)sender).Text + " y el ID del POKE es: " + argument;
        }*/
    }
}