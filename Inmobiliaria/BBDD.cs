using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Inmobiliaria
{
    class BBDD
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-U85FE9O;Initial Catalog=inmobiliaria;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        DataTable tabla; // = new DataTable();

        public DataTable Tabla
        {
            get => tabla;
        }
        
        public void LecturaBBDD(string consulta)
        {
            tabla = new DataTable();

            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consulta;
            tabla.Load(comando.ExecuteReader());

            conexion.Close();
        }

        public void EscrituraBBDD(string consulta)
        {
            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consulta;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

    }
}
