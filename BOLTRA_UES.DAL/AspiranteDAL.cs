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

        public AspiranteEN ObtenerPorUsuario(string usuario)
        {
            AspiranteEN obj = new AspiranteEN();

            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            conexion.Open();

            string sql = "SELECT nombres, apellidos, dui, fechaN, userN, pass," +
                "tipoUser, genero, estadoC, telefono, direccion FROM Aspirante WHERE userN LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);

            reader = comando.ExecuteReader();

            while (reader.Read())
            {
                obj.nombres = reader["nombres"].ToString();
                obj.apellidos = reader["apellidos"].ToString();
                obj.dui = reader["dui"].ToString();
                obj.fechaN = reader["fechaN"].ToString();
                obj.userN = reader["userN"].ToString();
                obj.pass = reader["pass"].ToString();
                obj.tipoUser = reader["tipoUser"].ToString();
                obj.genero = reader["genero"].ToString();
                obj.estadoC = reader["estadoC"].ToString();
                obj.telefono = reader["telefono"].ToString();
                obj.direccion = reader["direccion"].ToString();
            }
            return obj;
        }

        public AspiranteEN ObtenerAspirantePorId(string pIdAspirante)
        {
            AspiranteEN obj = new AspiranteEN();

            BDComun conexion = new BDComun();

            MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FORM Aspirante WHERE dui={0})", pIdAspirante), conexion.establecerConxion());
            MySqlDataReader reader = comando.ExecuteReader();

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
    }
}
