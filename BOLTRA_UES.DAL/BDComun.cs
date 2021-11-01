using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLTRA_UES.DAL
{
    public class BDComun
    {
        MySqlConnection conex = new MySqlConnection();

        static string servidor = "localhost";
        static string bd = "boltra_ues";
        static string usuario = "root";
        static string pass = "Cardona07";
        static string port = "3306";

        string cadenaConexion = "server=" + servidor + ";" + "port=" + port + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";

        public MySqlConnection establecerConxion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                //MessageBox.Show("Se conecto a la BD");
            }

            catch (MySqlException e)
            {
                //MessageBox.Show("No se pudo conectar a la base de datos" + e.ToString());
            }

            return conex;
        }
    }
}
