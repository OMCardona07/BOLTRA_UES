using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLTRA_UES.EN;
using System.Windows.Forms;

namespace BOLTRA_UES.DAL
{
    public class AspiranteDAL
    {
        public int AgregarAspirante(AspiranteEN pAspirante)
        {
            BDComun conexion = new BDComun();
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO Aspirante (nombres, apellidos, dui, fechaN," +
                "userN, pass, tipoUser, genero, estadoC, telefono, direccion) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                pAspirante.nombres, pAspirante.apellidos, pAspirante.dui, pAspirante.fechaN, pAspirante.userN, pAspirante.pass,
                pAspirante.tipoUser, pAspirante.genero, pAspirante.estadoC, pAspirante.telefono, pAspirante.direccion), conexion.establecerConxion());
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

        public int BuscarAspirante(string pUsuario, string pPass)
        {
            int resultado;
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "SELECT nombres, apellidos, dui, fechaN, userN, pass," +
                "tipoUser, genero, estadoC, telefono, direccion FROM Aspirante WHERE userN= @usuario and pass=  @pass";

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

        public AspiranteEN ObtenerAspiranteNombreUsu(string pUsuario, string pPass)
        {
            AspiranteEN obj = new AspiranteEN();
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "SELECT nombres, apellidos, dui, fechaN, userN, pass," +
                "tipoUser, genero, estadoC, telefono, direccion FROM Aspirante WHERE userN= @usuario and pass=  @pass";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", pUsuario);
            comando.Parameters.AddWithValue("@pass", pPass);
            reader = comando.ExecuteReader();


            while (reader.Read())
            {
                obj.nombres = reader.GetString(0);
                obj.apellidos = reader.GetString(1);
                obj.dui = reader.GetString(2);
                obj.fechaN = reader.GetString(3);
                obj.userN = reader.GetString(4);
                obj.pass = reader.GetString(5);
                obj.tipoUser = reader.GetString(6);
                obj.genero = reader.GetString(7);
                obj.estadoC = reader.GetString(8);
                obj.telefono = reader.GetString(9);
                obj.direccion = reader.GetString(10);
            }
            return obj;
        }

        public bool Loging(string pUsuario, string pPass)
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "SELECT nombres, apellidos, dui, fechaN, userN, pass," +
                "tipoUser, genero, estadoC, telefono, direccion FROM Aspirante WHERE userN= @usuario and pass=  @pass";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", pUsuario);
            comando.Parameters.AddWithValue("@pass", pPass);
            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Session.nombres = reader.GetString(0);
                    Session.apellidos = reader.GetString(1);
                    Session.dui = reader.GetString(2);
                    Session.fechaN = reader.GetString(3);
                    Session.userN = reader.GetString(4);
                    Session.pass = reader.GetString(5);
                    Session.tipoUser = reader.GetString(6);
                    Session.genero = reader.GetString(7);
                    Session.estadoC = reader.GetString(8);
                    Session.telefono = reader.GetString(9);
                    Session.direccion = reader.GetString(10);
                }
                return true;
            }
            else
                return false;
        }
    }
}
