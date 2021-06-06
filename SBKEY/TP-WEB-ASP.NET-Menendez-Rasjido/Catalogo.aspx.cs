using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Bussines;

namespace TP_WEB_ASP.NET_Menendez_Rasjido
{
    public partial class Catalogo : System.Web.UI.Page
    {
        public List<Articulo> listaCatalogo;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosBussines negocio = new ArticulosBussines();

            try
            {
                listaCatalogo = negocio.listar("");
               
               

                Session.Add("ListadoProducto", listaCatalogo);
          
            }
            catch(Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Default.aspx");
            }

        }
    }
}