using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bussines;
using Dominio;

using System.IO;

//Creado por Jose Enrique Menendez & Adriel Elian Rasjido

namespace Presentacion
{
    public partial class systemSimplex : Form
    {
        Login login = new Login();
        Detalles detalles = new Detalles();
        ArticulosBussines negocio=new ArticulosBussines();
        string where = " ";
        AccessData data=new AccessData("(local)\\SQLEXPRESS", "CATALOGO_DB");
        public systemSimplex()
        {
            InitializeComponent();
        }

        //Funcion para hacer visibles solos los items que se usan en el momentos
        private void Visibilidad(short aux) {
            dataGridViewListar.DataSource = null;
            where = " ";
            switch (aux)
            {
                case 0:
                    todoToolStripMenuItem.Checked = true;
                    textBoxPrecioMAX.Visible = textBoxPrecioMIN.Visible = textBoxListar.Visible = labelListar.Visible = labelRangoPreciolistar.Visible = comboBoxCate_Marca.Visible = labelCategorias_o_Marcas.Visible = false;
                    break;
                case 1:
                    todoToolStripMenuItem.Checked = false;
                    textBoxPrecioMAX.Visible = textBoxPrecioMIN.Visible = comboBoxCate_Marca.Visible = labelRangoPreciolistar.Visible = labelCategorias_o_Marcas.Visible = false;
                    textBoxListar.Visible = labelListar.Visible = true;
                    textBoxListar.Text = " ";
                    break;
                case 2:
                    todoToolStripMenuItem.Checked = false;
                    textBoxListar.Visible = labelListar.Visible = comboBoxCate_Marca.Visible = labelCategorias_o_Marcas.Visible = false;
                    textBoxPrecioMAX.Visible = textBoxPrecioMIN.Visible = labelRangoPreciolistar.Visible = true;
                    break;
                case 3:
                    todoToolStripMenuItem.Checked = false;
                    comboBoxCate_Marca.Items.Clear();
                    comboBoxCate_Marca.Text = " ";
                    textBoxPrecioMAX.Visible = textBoxPrecioMIN.Visible = textBoxListar.Visible = labelListar.Visible = labelRangoPreciolistar.Visible = false;
                    comboBoxCate_Marca.Visible = labelCategorias_o_Marcas.Visible = true;
                    break;
                case 4:
                    textBoxCodAdd.Text = ""; textBoxDescripAdd.Text = ""; textBoxIdAdd.Text = ""; textBoxNombreAdd.Text = ""; textBoxPrecioAdd.Text = ""; textBoxUrlAdd.Text = ""; buttonAdd.Enabled = false;
                    pictureBoxAdd.Load("https://png.pngtree.com/png-vector/20190927/ourlarge/pngtree-red-cross-with-the-outline-coming-out-png-image_1761934.jpg");
                    break;
                case 5:
                    buttonConf.Enabled = false;
                    textBoxPassAct.Text = ""; textBoxPassNew.Text = ""; textBoxPassAct.Visible = false; textBoxUserAct.Visible = false;
                    textBoxUserAct.Text = ""; textBoxUserNew.Text = ""; labelPassAct.Visible = false;   labelUserAct.Visible = false;
                    break;
            }
        }

        //Boton buscar de Listar
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            where = " ";
            if (crear_where() || todoToolStripMenuItem.Checked == true)
            {
                dataGridViewListar.DataSource = negocio.listar(where);
                dataGridViewListar.Columns[6].Visible = false;
            }
        }

        //Opción de barra de menu Listar Todo
        private void todoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visibilidad(0); tabControl.SelectedIndex = 1;
        }

        //Opción de barra de menu Listar por ID
        private void iDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visibilidad(1); tabControl.SelectedIndex = 1;
            labelListar.Text = IDToolStripMenuItem.Text;
        }

        //Opción de barra de menu Listar por Codigo de Articulo
        private void codigoDeArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1; Visibilidad(1);
            labelListar.Text = codigoToolStripMenuItem.Text;
        }

        //Opción de barra de menu Listar por Nombre
        private void nombreDeArticulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1; Visibilidad(1);           
            labelListar.Text = nombreDeArticulToolStripMenuItem.Text;
        }

        //Opción de barra de menu Listar por Descripcion
        private void descripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1; Visibilidad(1);
            labelListar.Text = descripcionToolStripMenuItem.Text;
        }

        //Opción de barra de menu Listar por Marca
        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visibilidad(3); tabControl.SelectedIndex = 1;
            labelCategorias_o_Marcas.Text = marcaToolStripMenuItem.Text;
            Listarcombobox(ref comboBoxCate_Marca, "select * from marcas");
        }

        //Opción de barra de menu Listar por Categoria
        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visibilidad(3);
            labelCategorias_o_Marcas.Text = categoriaToolStripMenuItem.Text;
            Listarcombobox(ref comboBoxCate_Marca, "select * from categorias"); 
        }

        //Opcion de barra de menu Listar por Rango de precio
        private void rangoDePrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1; Visibilidad(2);
            textBoxPrecioMAX.Text = textBoxPrecioMIN.Text=" ";
        }

        //Opcion de barra de menu Agregar articulo
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 3;
            Visibilidad(4); comboboxsAdd();
            try{
                data.setearConsulta("select * from articulos"); int UltimaId = 1;
                data.ejecutarLectura();
                while (data.Lector.Read()) { UltimaId++; }
                textBoxIdAdd.Text = UltimaId.ToString();
            }
            catch (Exception ex) { throw ex; }
            finally { data.cerrarConexion(); }
        }
        
        //Opcion de barra de menu Modificar articulo
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
            comboBoxMarcaMod.Items.Clear();
            comboBoxCategMod.Items.Clear();
            Listarcombobox(ref comboBoxMarcaMod, "select * from marcas");
            Listarcombobox(ref comboBoxCategMod, "select * from categorias");
        }

        //Opcion de barra de menu Configuracion
        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 4; Visibilidad(5);
        }

        //Agrega los elementos al combobox marca y descripcion de Add
        private void comboboxsAdd()
        {
            if (tabControl.SelectedIndex == 3)
            {
                comboBoxMarcaAdd.Items.Clear(); comboBoxCategAdd.Items.Clear();
                Listarcombobox(ref comboBoxMarcaAdd,"select * from marcas");
                Listarcombobox(ref comboBoxCategAdd, "select * from categorias");
                buttonAdd.Enabled = false;
            }
        }

        //Verifica si estan completo todos los datos solicitados
        private void changedAddVerific(object sender, EventArgs e)
        {
            int cont = 0;
            if (textBoxCodAdd.Text != "") { cont++; }
            if (textBoxNombreAdd.Text != "") { cont++; }
            if (textBoxPrecioAdd.Text != "") { cont++; }
            if (textBoxDescripAdd.Text != "") { cont++; }
            else
            {
                try
                {
                    labelUrlAdd.BackColor = Color.Black;
                    pictureBoxAdd.Load(textBoxUrlAdd.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                    labelUrlAdd.BackColor = Color.Red;
                    pictureBoxAdd.Load("https://png.pngtree.com/png-vector/20190927/ourlarge/pngtree-red-cross-with-the-outline-coming-out-png-image_1761934.jpg");
                }
            }
            if (textBoxUrlAdd.Text != "") { cont++; }
            if (comboBoxMarcaAdd.Text != "") { cont++; }
            if (comboBoxCategAdd.Text != "") { cont++; }
            if (cont == 7){ buttonAdd.Enabled = true;}
            else { buttonAdd.Enabled = false; }
        }
        
        //Al precionar el boton Agregar
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show
            ("DESEAS AGREGAR ESTE NUEVO PRODUCTO?", "ADVERTENCIA",MessageBoxButtons.YesNoCancel);
            switch (resultado.ToString())
            {
                case "Yes":
                    string queryAdd = "insert into articulos values ('";
                    queryAdd += textBoxCodAdd.Text + "','"; queryAdd += textBoxNombreAdd.Text + "','"; queryAdd += textBoxDescripAdd.Text + "',";
                    int cbmarca = comboBoxMarcaAdd.SelectedIndex + 1; queryAdd += cbmarca + ",";
                    int cbcateg = comboBoxCategAdd.SelectedIndex + 1; queryAdd += cbcateg + ",'";
                    queryAdd += textBoxUrlAdd.Text + "',"; queryAdd += textBoxPrecioAdd.Text + ")";
                    data.setearConsulta(queryAdd);
                    data.ejectutarAccion(); data.cerrarConexion();
                    MessageBox.Show("Articulo agregado con exito!");
                break;
                case "Cancel":
                    Visibilidad(4);
                break;
            }
        }

        //Cargar el Login
        private void Window_Load(object sender, EventArgs e)
        {
           login.ShowDialog();
           if (login.close) { this.Close(); }
        }
        
        //Agregar items al combobox
        private void Listarcombobox(ref ComboBox aux,string consulta){
            try{
                data.setearConsulta(consulta); data.ejecutarLectura();
                while (data.Lector.Read()){ aux.Items.Add((string)data.Lector["descripcion"]);}
            }catch (Exception ex){ throw ex; } finally{ data.cerrarConexion();}
        }

        //Lista Mod al encontrar un cambio en la consulta
        private void cambioMod(object sender,EventArgs e)
        {
            dataGridMod.DataSource = negocio.listar(condicionMod());
        }

        //Crea el Where de Modificar segun los campos llenados
        private string condicionMod()
        {
            bool andc = false; int cont = 0; string queryCondicion = " where ";
            if (textBoxIdMod.Text != "") { queryCondicion += "A.id = " + textBoxIdMod.Text; andc = true; cont++; }

            if (andc == true && textBoxCodMod.Text != "") { queryCondicion += " and "; andc = false; }
            if (textBoxCodMod.Text != "") { queryCondicion += "A.codigo LIKE '%" + textBoxCodMod.Text + "%'"; andc = true; cont++; }

            if (andc == true && textBoxNombreMod.Text != "") { queryCondicion += " and "; andc = false; }
            if (textBoxNombreMod.Text != "") { queryCondicion += "A.nombre LIKE '%" + textBoxNombreMod.Text + "%'"; andc = true; cont++; }

            if (andc == true && textBoxDescripMod.Text != "") { queryCondicion += " and "; andc = false; }
            if (textBoxDescripMod.Text != "") { queryCondicion += "A.descripcion LIKE '%" + textBoxDescripMod.Text + "%'"; andc = true; cont++; }

            if (andc == true && textBoxPrecioMod.Text != "" || andc == true && textBoxPrecioMinMod.Text != "" || andc == true && textBoxPrecioMaxMod.Text != "")
            { queryCondicion += " and "; andc = false; cont++; }

            if (textBoxPrecioMod.Text != "") { queryCondicion += "A.precio = " + textBoxPrecioMod.Text; andc = true; cont++; }
            else if (textBoxPrecioMinMod.Text != "" && textBoxPrecioMaxMod.Text != "" && decimal.Parse(textBoxPrecioMinMod.Text) < decimal.Parse(textBoxPrecioMaxMod.Text))
            { queryCondicion += " A.precio between " + decimal.Parse(textBoxPrecioMinMod.Text) + " and " + decimal.Parse(textBoxPrecioMaxMod.Text); andc = true; cont++; }
            else if (textBoxPrecioMinMod.Text != "") { queryCondicion += "A.precio >= " + decimal.Parse(textBoxPrecioMinMod.Text); andc = true; cont++; }
            else if (textBoxPrecioMaxMod.Text != "") { queryCondicion += "A.precio <= " + decimal.Parse(textBoxPrecioMaxMod.Text); andc = true; cont++; }

            if (andc == true && comboBoxMarcaMod.SelectedIndex >= 0) { queryCondicion += " and "; andc = false; }
            if (comboBoxMarcaMod.SelectedIndex >= 0)
            {
                int cb = comboBoxMarcaMod.SelectedIndex + 1;
                queryCondicion += "A.idMarca = " + cb.ToString();
                andc = true; cont++;
            }

            if (andc == true && comboBoxCategMod.SelectedIndex >= 0) { queryCondicion += " and "; }
            if (comboBoxCategMod.SelectedIndex >= 0)
            {
                int cb = comboBoxCategMod.SelectedIndex + 1;
                queryCondicion += "A.idCategoria = " + cb.ToString();
                cont++;
            }
            if (cont == 0) { queryCondicion = ""; }
            return queryCondicion;
        }

        //Crea el Where
        private bool crear_where()
        {
            bool consultar = true;
            if (labelListar.Visible && labelListar.Text == "ID" && textBoxListar.TextLength > 0)
            { where = "where A.Id= '" + textBoxListar.Text + "'"; }

            else if (labelListar.Visible && labelListar.Text == "Codigo" && textBoxListar.TextLength > 0)
            { where = "where A.Codigo like  '%" + textBoxListar.Text + "%'"; }

            else if (labelListar.Visible && labelListar.Text == "Nombre" && textBoxListar.TextLength > 0)
            { where = "where A.Nombre like '%" + textBoxListar.Text + "%'"; }

            else if (labelListar.Visible && labelListar.Text == "Descripcion" && textBoxListar.TextLength > 0)
            { where = "where A.Descripcion like '%" + textBoxListar.Text + "%'"; }

            else if (labelCategorias_o_Marcas.Visible && labelCategorias_o_Marcas.Text == "Marca" && comboBoxCate_Marca.SelectedIndex >= 0)
            { where = "where M.Descripcion = '" + comboBoxCate_Marca.SelectedItem + "'"; }

            else if (labelCategorias_o_Marcas.Visible && labelCategorias_o_Marcas.Text == "Categoria" && comboBoxCate_Marca.SelectedIndex >= 0)
            { where = "where C.Descripcion = '" + comboBoxCate_Marca.SelectedItem + "'"; }

            else if (labelRangoPreciolistar.Visible && textBoxPrecioMAX.TextLength > 0 && textBoxPrecioMIN.TextLength > 0 && decimal.Parse(textBoxPrecioMAX.Text) > decimal.Parse(textBoxPrecioMIN.Text))
            { where = "where A.Precio between " + textBoxPrecioMIN.Text + " and " + textBoxPrecioMAX.Text; }
            else consultar = false;
            return consultar;
        }

        //Pregunta si desea modificar la cantidad de datos especificada
        public bool cantidadModificar(int cant)
        {
            bool opc = false;
            DialogResult result = MessageBox.Show("DESEAS MODIFICAR " + cant + " ARTICULOS?", "ADVERTENCIA", MessageBoxButtons.YesNo);
            if (result.ToString() == "Yes") { opc = true; }
            return opc;
        }

        //Al presionar el boton Modificar / Aplicar
        private void buttonMod_Click(object sender, EventArgs e)
        {
            if (buttonMod.Text == "MODIFICAR")
            {
                data.setearConsulta("select * from articulos " + condicionMod());
                data.ejecutarLectura(); int cant = 0;
                while (data.Lector.Read()){ cant++;} data.cerrarConexion();
             
                if (cantidadModificar(cant) == true)
                {
                    textBoxIdMod.Text = "";             textBoxPrecioMinMod.Text = "";
                    textBoxPrecioMinMod.Text = "";      textBoxPrecioMaxMod.Text = "";
                    textBoxPrecioMaxMod.Text = "";      buttonMod.Text = "APLICAR";
                    textBoxIdMod.Enabled = true;        textBoxUrlMod.Visible = true;
                    textBoxPrecioMinMod.Enabled = true; textBoxPrecioMinMod.Visible = false;
                    textBoxPrecioMaxMod.Enabled = true; textBoxPrecioMaxMod.Visible = false;
                    textBoxUrlMod.Enabled = false; 
                }
            }
            else
            {
                data.setearConsulta("select * from articulos " + condicionMod());
                data.ejecutarLectura(); int cant = 0;
                while (data.Lector.Read()) { cant++; } data.cerrarConexion();

                if (cantidadModificar(cant) == true)
                {
                    bool and = false;
                    string update = "update articulos set ";
                    if (textBoxIdMod.Text != "") { update += " id = " + textBoxIdMod.Text; and = true; }

                    if (and == true && textBoxCodMod.Text != "") {              update += ", "; and = false; }
                    if (textBoxCodMod.Text != "") { update += " codigo = '" + textBoxCodMod.Text + "'"; and = true; }

                    if (and == true && textBoxNombreMod.Text != "") {           update += ", "; and = false; }
                    if (textBoxNombreMod.Text != "") { update += "  nombre = '" + textBoxNombreMod.Text + "'"; and = true; }

                    if (and == true && textBoxDescripMod.Text != "") {          update += ", "; and = false; }
                    if (textBoxDescripMod.Text != "") { update += "descripcion ='" + textBoxDescripMod.Text + "'"; and = true; }

                    if (and == true && textBoxPrecioMod.Text != "") {           update += ", "; and = false; }
                    if (textBoxPrecioMod.Text != "") { update += "precio =" + textBoxPrecioMod.Text; and = true; }

                    if (and == true && comboBoxMarcaMod.SelectedIndex >= 0) {   update += ", "; and = false; }
                    if (comboBoxMarcaMod.SelectedIndex >= 0)
                    {
                        int cb = comboBoxMarcaMod.SelectedIndex + 1;
                        update += "idMarca = " + cb.ToString(); and = true;
                    }
                    if (and == true && comboBoxCategMod.SelectedIndex >= 0) {   update += ", ";}
                    if (comboBoxCategMod.SelectedIndex > 0)
                    {
                        int cb = comboBoxCategMod.SelectedIndex + 1;
                        update += "idCategoria = " + cb.ToString();
                    }
                    data.setearConsulta(update + condicionMod());
                    data.ejectutarAccion(); data.cerrarConexion();
                    MessageBox.Show("Los cambios fueron cambiados exitosamente");
                    dataGridMod.DataSource = negocio.listar(condicionMod());

                    buttonMod.Text = "MODIFICAR";        textBoxUrlMod.Text = "";
                    textBoxPrecioMinMod.Enabled = false; textBoxUrlMod.Visible = false;
                    textBoxPrecioMaxMod.Enabled = false; textBoxIdMod.Enabled = false;
                    textBoxPrecioMinMod.Visible = true;  textBoxPrecioMaxMod.Visible = true; 
                    textBoxUrlMod.Enabled = true;       
                }
                else
                {
                    buttonMod.Text = "MODIFICAR";        textBoxUrlMod.Text = ""; 
                    textBoxPrecioMinMod.Enabled = false; textBoxIdMod.Enabled = false;
                    textBoxPrecioMaxMod.Enabled = false; textBoxUrlMod.Visible = false;
                    textBoxPrecioMinMod.Visible = true;  textBoxUrlMod.Enabled = true;
                    textBoxPrecioMaxMod.Visible = true; 
                }
            }
        }

        //Al presionar el boton Eliminar
        private void buttonDel_Click(object sender, EventArgs e)
        {
            int cant = 0;
            data.setearConsulta("select * from articulos " + condicionMod());
            data.ejecutarLectura();
            while (data.Lector.Read()) { cant++; } data.cerrarConexion();

            if (cantidadModificar(cant) == true)
            {
                data.setearConsulta("delete * from articulos" + condicionMod());
                data.ejectutarAccion(); data.cerrarConexion();
                MessageBox.Show("Los cambios fueron cambiados exitosamente");
                dataGridMod.DataSource = negocio.listar(condicionMod());
            }
        }

        //Inicio de Colores de botones al pasar el mouse por ensima
        private void buttonBuscar_MouseHover(object sender, EventArgs e){   buttonBuscar.BackColor = Color.Black;}
        private void buttonBuscar_MouseLeave(object sender, EventArgs e){   buttonBuscar.BackColor = Color.DimGray;}
        private void buttonMod_MouseHover(object sender, EventArgs e){      buttonMod.BackColor = Color.Black;}
        private void buttonMod_MouseLeave(object sender, EventArgs e){      buttonMod.BackColor = Color.DimGray;}
        private void buttonDel_MouseHover(object sender, EventArgs e){      buttonDel.BackColor = Color.Black;}
        private void buttonDel_MouseLeave(object sender, EventArgs e){      buttonDel.BackColor = Color.DimGray;}
        private void buttonAdd_MouseHover(object sender, EventArgs e){      buttonAdd.BackColor = Color.Black;}
        private void buttonAdd_MouseLeave(object sender, EventArgs e){      buttonAdd.BackColor = Color.DimGray; }
        //Fin de Colores de botones al pasar el mouse por ensima

        //Validar key's de Id
        private void validacion_keyPressID(object sender, KeyPressEventArgs e)
        {
            if ((tabControl.SelectedIndex == 1 && labelListar.Text == "ID") || tabControl.SelectedIndex == 2 || tabControl.SelectedIndex == 3)
                if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8) e.Handled = true;
        }
        
        //Validar key's de Precio
        private void validacion_keyPressPrecio(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8 && e.KeyChar != 46) e.Handled = true;
        }

        //Lista los detalles al clickear sobre una celda
        private void dataGridViewListar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedCellCount = dataGridViewListar.GetCellCount(DataGridViewElementStates.Selected);
            int fila = -1;
            if (selectedCellCount > 0)
            {
                new System.Text.StringBuilder();
                for (int i = 0; i < selectedCellCount; i++){ fila = dataGridViewListar.SelectedCells[i].RowIndex;}
                detalles.id(dataGridViewListar[0, fila].Value.ToString());
                detalles.cod(dataGridViewListar[1, fila].Value.ToString());
                detalles.nombre(dataGridViewListar[2, fila].Value.ToString());
                detalles.descrip(dataGridViewListar[3, fila].Value.ToString());
                detalles.marca(dataGridViewListar[4, fila].Value.ToString());
                detalles.categ(dataGridViewListar[5, fila].Value.ToString());
                detalles.imagen(dataGridViewListar[6, fila].Value.ToString());
                detalles.precio(dataGridViewListar[7, fila].Value.ToString());
                detalles.ShowDialog();
            }
        }

        //Verifica que opcion se encuentra en configuracion
        private void cambiocheck(object sender, EventArgs e)
        {
            Visibilidad(5);
            if (radioButtonCamb.Checked == true)
            {
                labelUserAct.Visible = true; textBoxUserAct.Visible = true;
                labelPassAct.Visible = true; textBoxPassAct.Visible = true;
            }
            else
            {
                labelUserAct.Visible = false; textBoxUserAct.Visible = false;
                labelPassAct.Visible = false; textBoxPassAct.Visible = false;
            }
        }

        //Verifica si todos los campos estan completos en configuracion
        private void cambioConfig(object sender,EventArgs e)
        {
            if (radioButtonCamb.Checked == true && textBoxUserAct.Text != "" && textBoxUserNew.Text != "" && textBoxPassAct.Text != "" && textBoxPassNew.Text != "") { buttonConf.Enabled = true; }
            else if (radioButtonCamb.Checked == false && textBoxUserNew.Text != "" && textBoxPassNew.Text != "") { buttonConf.Enabled = true; }
            else { buttonConf.Enabled = false; }
        }

        //Crea la clase usuarios para almacenar los User y Pass
        class usuarios
        {
            public string us { get; set; }
            public string pss { get; set; }
        }

        //Al precionar el boton conf - Asi mismo crea un respaldo de User y Pass
        private void buttonConf_Click(object sender, EventArgs e)
        {
            bool user = false; bool error = true;
            if (radioButtonCamb.Checked == true)
            {
                StreamReader archivo = new StreamReader("Usuarios_Login.txt");
                int x = 0; int y = 0;
                string text = " "; string users = ""; string pass = "";
                while ((text = archivo.ReadLine()) != null)
                {
                    x++;
                    if (x % 2 != 0){ users = text;
                        if (textBoxUserAct.Text == text){ user = true;}
                    }
                    else
                    {
                        new usuarios() { us = users,pss=pass, };
                        if (user == true && textBoxPassAct.Text==text)
                        {
                            error = false;
                            List<usuarios> listaUser = new List<usuarios>();
                            DialogResult result = MessageBox.Show("DESEAS CAMBIAR TU USUARIO Y CONTRASEÑA?", "ADVERTENCIA", MessageBoxButtons.YesNo);
                            if (result.ToString() == "Yes")
                            {
                                listaUser[y].us = textBoxUserNew.Text;
                                listaUser[y].pss = textBoxPassNew.Text;
                                archivo.Close();
                                File.Delete("Usuarios_Login.txt");
                                TextWriter escribir = new StreamWriter("Usuarios_Login.txt");
                                for(int z = 0; z < listaUser.Count(); z++)
                                {
                                    escribir.WriteLine(listaUser[z].us);
                                    escribir.WriteLine(listaUser[z].pss);
                                }
                                MessageBox.Show("Cambios agregados correctamente");
                                listaUser.Clear();
                            }
                        }
                        else{ user = false;}
                    }
                    y++;
                }
            }
            else
            {
                error = false;
                TextWriter escribir = new StreamWriter("Usuarios_Login.txt");
                DialogResult result = MessageBox.Show("DESEAS AGREGAR UN NUEVO USUARIO?", "ADVERTENCIA", MessageBoxButtons.YesNo);
                if (result.ToString() == "Yes")
                {
                    escribir.WriteLine(textBoxUserNew.Text);
                    escribir.WriteLine(textBoxPassNew.Text);
                    escribir.Close();
                    MessageBox.Show("Cambios agregados correctamente");
                }
            }
            if (error == true) { MessageBox.Show("Hubo un error, verifica el usuario y contraseña"); }
        }
    }
}
