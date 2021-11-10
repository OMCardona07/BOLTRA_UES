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

        public bool Loging(string pUsuario, string pPass)
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "SELECT idA, nombres, apellidos, dui, fechaN, userN, pass," +
                "tipoUser, genero, estadoC, telefono, direccion FROM Aspirante WHERE userN= @usuario and pass=  @pass";

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
                    Session.genero = reader.GetString(8);
                    Session.estadoC = reader.GetString(9);
                    Session.telefono = reader.GetString(10);
                    Session.direccion = reader.GetString(11);
                }
                return true;
            }
            else
                return false;
        }



        public int ModificarAspirante(AspiranteEN pAspirante)
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "UPDATE Aspirante SET nombres=@nombres, apellidos=@apellidos, dui=@dui," +
                "fechaN=@fechaN, userN=@userN, pass=@pass, tipoUser=@tipoUser, genero=@genero," +
                "estadoC=@estadoC, telefono=@telefono, direccion=@direccion WHERE idA = @id";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@id", pAspirante.id);
            comando.Parameters.AddWithValue("@nombres", pAspirante.nombres);
            comando.Parameters.AddWithValue("@apellidos", pAspirante.apellidos);
            comando.Parameters.AddWithValue("@dui", pAspirante.dui);
            comando.Parameters.AddWithValue("@fechaN", pAspirante.fechaN);
            comando.Parameters.AddWithValue("@userN", pAspirante.userN);
            comando.Parameters.AddWithValue("@pass", pAspirante.pass);
            comando.Parameters.AddWithValue("@tipoUser", pAspirante.tipoUser);
            comando.Parameters.AddWithValue("@genero", pAspirante.genero);
            comando.Parameters.AddWithValue("@estadoC", pAspirante.estadoC);
            comando.Parameters.AddWithValue("@telefono", pAspirante.telefono);
            comando.Parameters.AddWithValue("@direccion", pAspirante.direccion);
            int resultado = comando.ExecuteNonQuery();
            conexion.Close();
            return resultado;
        }

        public List<AspiranteEN> RecuperarDatos()
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader LeerFilas;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();
            string sql = "SELECT * FROM  Aspirante";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            LeerFilas = comando.ExecuteReader();

            List<AspiranteEN> _datosAspirante = new List<AspiranteEN>();

            while (LeerFilas.Read())
            {
                _datosAspirante.Add(new AspiranteEN
                {
                    id = LeerFilas.GetInt64(0),
                    nombres = LeerFilas.GetString(1),
                    apellidos = LeerFilas.GetString(2),
                    dui = LeerFilas.GetString(3),
                    fechaN = LeerFilas.GetString(4),
                    userN = LeerFilas.GetString(5),
                    pass = LeerFilas.GetString(6),
                    tipoUser = LeerFilas.GetString(7),
                    genero = LeerFilas.GetString(8),
                    estadoC = LeerFilas.GetString(9),
                    telefono = LeerFilas.GetString(10),
                    direccion = LeerFilas.GetString(11),
                });

            }
            LeerFilas.Close();
            return _datosAspirante;
        }
    }
}
