using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TP_WEB_ASP.NET_Menendez_Rasjido
{
    public partial class Detalles_de_Productos : System.Web.UI.Page
    {
        public Articulo detalleArt;
        protected void Page_Load(object sender, EventArgs e)
        {

            int id = int.Parse(Request.QueryString["id"]);
                      
            List<Articulo> listado = (List<Articulo>)Session["ListadoProducto"];
            detalleArt =listado.Find(x => x.ID==id);

            }

       


    }
}