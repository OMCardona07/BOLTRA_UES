using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLTRA_UES.EN;
using MySql.Data.MySqlClient;

namespace BOLTRA_UES.DAL
{
    public class AdministradorDAL
    {
        public int AgregarAdmin(AdministradorEN pAspirante)
        {
            BDComun conexion = new BDComun();
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO Administrador (nombres, apellidos, dui, fechaN," +
                "userN, pass, tipoUser) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                pAspirante.nombres, pAspirante.apellidos, pAspirante.dui, pAspirante.fechaN, pAspirante.userN, pAspirante.pass,
                pAspirante.tipoUser), conexion.establecerConxion());
            retorno = comando.ExecuteNonQuery();
            try
            {
                return retorno;
            }

            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error inesperado" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return retorno;
            }
        }

        public int BuscarAdmin(string pUsuario, string pPass)
        {
            int resultado;
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "SELECT * FROM Administrador WHERE userN= @usuario and pass=  @pass";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", pUsuario);
            comando.Parameters.AddWithValue("@pass", pPass);
            reader = comando.ExecuteReader();
            AspiranteEN asp = new AspiranteEN();

            if (reader.Read())
            {
                resultado = 1;

            }
            else
            {
                resultado = 0;
            }
            conexion.Close();
            return resultado;
        }

        public bool Loging(string pUsuario, string pPass)
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "SELECT idAdmin, nombres, apellidos, dui, fechaN, userN, pass," +
                "tipoUser FROM Administrador WHERE userN= @usuario and pass=  @pass";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", pUsuario);
            comando.Parameters.AddWithValue("@pass", pPass);
            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Session.id = reader.GetInt64(0);
                    Session.nombres = reader.GetString(1);
                    Session.apellidos = reader.GetString(2);
                    Session.dui = reader.GetString(3);
                    Session.fechaN = reader.GetString(4);
                    Session.userN = reader.GetString(5);
                    Session.pass = reader.GetString(6);
                    Session.tipoUser = reader.GetString(7);

                }
                return true;
            }
            else
                return false;
        }
    }
}
