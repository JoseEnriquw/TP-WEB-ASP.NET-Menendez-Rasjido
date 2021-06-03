using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Presentacion
{
    public class AccessData
    {
        public string host { get; set; }
        public string database { get; set; }
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public AccessData()
        {
            string connection = "data source=" + host + ";initial catalog=" + database + ";integrated security=true;";
            conexion = new SqlConnection(connection);
            comando = new SqlCommand();
        }

        public AccessData(string connection)
        {
            conexion = new SqlConnection(connection);
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        internal void ejectutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }
    }
}
