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
        public List<Categorias_y_Marcas> listafiltros;
        bool listdrop = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosBussines negocio = new ArticulosBussines();



            try
            {
                listaCatalogo = negocio.listar("");

                Session.Add("ListadoProducto", listaCatalogo);

                if (DropDownList2.Text == "" && DropDownList3.Text == "")
                {
                    DropDownList2.Items.Add("NONE");
                    DropDownList3.Items.Add("NONE");
                    listdrop = true;
                }

                if (listdrop == true)
                {
                    listafiltros = negocio.listar2("select * from Categorias");
                    Session.Add("ListaFiltro", listafiltros);
                    foreach (Dominio.Categorias_y_Marcas item in listafiltros)
                    {
                        DropDownList2.Items.Add(item.Nombre);
                    }

                    listafiltros = negocio.listar2("select * from Marcas");
                    Session.Add("ListaFiltro", listafiltros);
                    foreach (Dominio.Categorias_y_Marcas item in listafiltros)
                    {
                        DropDownList3.Items.Add(item.Nombre);

                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }

        }
        protected void filterDefault(object sender, EventArgs e)
        {
            ArticulosBussines negocio = new ArticulosBussines();

            try
            {
                listaCatalogo = negocio.listar("");

                Session.Add("ListadoProducto", listaCatalogo);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Default.aspx");
            }
        }
        protected void filterMinPrecio(object sender, EventArgs e)
        {
            ArticulosBussines negocio = new ArticulosBussines();

            try
            {
                listaCatalogo = negocio.listar("ORDER BY precio ASC");

                Session.Add("ListadoProducto", listaCatalogo);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Default.aspx");
            }
        }
        protected void filterMaxPrecio(object sender, EventArgs e)
        {
            ArticulosBussines negocio = new ArticulosBussines();

            try
            {
                listaCatalogo = negocio.listar("ORDER BY precio DESC");

                Session.Add("ListadoProducto", listaCatalogo);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Default.aspx");
            }
        }
        protected void filterRecientes(object sender, EventArgs e)
        {
            ArticulosBussines negocio = new ArticulosBussines();

            try
            {
                listaCatalogo = negocio.listar("ORDER BY id ASC");

                Session.Add("ListadoProducto", listaCatalogo);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Default.aspx");
            }
        }
        protected void filterAntiguos(object sender, EventArgs e)
        {
            ArticulosBussines negocio = new ArticulosBussines();

            try
            {
                listaCatalogo = negocio.listar("ORDER BY id DESC");

                Session.Add("ListadoProducto", listaCatalogo);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Default.aspx");
            }
        }
        protected void filterCat(object sender, EventArgs e)
        {
            ArticulosBussines negocio = new ArticulosBussines();

            try
            {
                if (DropDownList2.Text != "NONE")
                {
                    if (DropDownList3.Text != "NONE") listaCatalogo = negocio.listar("where c.descripcion = '" + DropDownList2.Text + "' and m.descripcion = '" + DropDownList3.Text + "' ");
                    else listaCatalogo = negocio.listar("where c.descripcion = '" + DropDownList2.Text + "'");


                }
                else if (DropDownList3.Text != "NONE")
                {
                    listaCatalogo = negocio.listar("where M.descripcion= '" + DropDownList3.Text + "'");
                }
                else
                {
                    filterDefault(sender, e);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Default.aspx");
            }
        }
        protected void filterMar(object sender, EventArgs e)
        {
            ArticulosBussines negocio = new ArticulosBussines();

            try
            {
                if (DropDownList3.Text != "NONE")
                {
                    if (DropDownList2.Text != "NONE") listaCatalogo = negocio.listar("where M.descripcion= '" + DropDownList3.Text + "' and c.descripcion = '" + DropDownList2.Text + "'");
                    else listaCatalogo = negocio.listar("where M.descripcion= '" + DropDownList3.Text + "'");

                    Session.Add("ListadoProducto", listaCatalogo);
                }
                else if (DropDownList2.Text != "NONE")
                {
                    listaCatalogo = negocio.listar("where c.descripcion = '" + DropDownList2.Text + "'");
                }
                else
                {
                    filterDefault(sender, e);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Default.aspx");
            }
        }

        protected void filterprecio(object sender, EventArgs e)
        {
            ArticulosBussines negocio = new ArticulosBussines();
            if (TextBox1.Text.Length != 0 && TextBox2.Text.Length != 0)
            {
                listaCatalogo = negocio.listar("where a.precio between " + decimal.Parse(TextBox1.Text) + " and " + decimal.Parse(TextBox2.Text));
            }
            else if (TextBox1.Text.Length != 0)
            {
                listaCatalogo = negocio.listar("where a.precio >= " + decimal.Parse(TextBox1.Text));
            }
            else if (TextBox2.Text.Length != 0)
            {
                listaCatalogo = negocio.listar("where a.precio <= " + decimal.Parse(TextBox2.Text));
            }
            else
            {
                filterDefault(sender, e);
            }
            Session.Add("ListadoProducto", listaCatalogo);
        }
    }
}