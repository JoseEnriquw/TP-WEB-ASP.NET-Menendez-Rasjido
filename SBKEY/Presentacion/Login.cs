using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Presentacion
{
    public partial class Login : Form
    {
        public bool close;
        private bool logueado;
        
        public Login()
        {
            InitializeComponent();
            close = logueado = false;
            //Pregunta si existe el archivo, sino lo crea y le carga los datos de usuarios por defecto
            if (!File.Exists("Usuarios_Login.txt")) {
                TextWriter escribir = new StreamWriter("Usuarios_Login.txt");
                escribir.WriteLine("Usuario");
                escribir.WriteLine("123456");
                escribir.WriteLine("Administrador");
                escribir.WriteLine("123456");
                escribir.Close();
            };
        }

        //Al presionar el boton Login
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            StreamReader archivo = new StreamReader("Usuarios_Login.txt");
            int x=0;
            string text=" ";
            bool aux = false;
            bool salir_while=true;
            while((text=archivo.ReadLine()) != null && salir_while) { x++;
                if (x % 2 == 0)
                {
                    if(textBoxPass.Text == text && aux)
                    {
                        MessageBox.Show("Logueado correctamente"); logueado = true;
                        salir_while = false; this.Close();
                    }
                    else aux = false;
                }
                else
                {
                    if (textBoxUser.Text == text) aux = true; else aux = false;
                }
            }
            if(!aux) MessageBox.Show("Hubo un error, verifica tu usario o contraseña"); archivo.Close();
        }

        //Al cerrar el login
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (logueado==false) { close = true; }
        }

        //Inicio botones colores
        private void buttonLogin_MouseHover(object sender, EventArgs e){ buttonLogin.BackColor = Color.Aquamarine; buttonLogin.ForeColor = Color.Black; }
        private void buttonLogin_MouseLeave(object sender, EventArgs e){ buttonLogin.BackColor = Color.Black; buttonLogin.ForeColor = Color.White; }
        //Fin botones colores
    }
}
