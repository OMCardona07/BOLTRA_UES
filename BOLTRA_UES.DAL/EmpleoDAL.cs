using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLTRA_UES.EN;
using MySql.Data.MySqlClient;

namespace BOLTRA_UES.DAL
{
    public class EmpleoDAL
    {
        public int AgregarEmpleo(EmpleoEN pEmpleo)
        {
            BDComun conexion = new BDComun();
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO Empleos (nombre, idEmpresa, descripcion) VALUES('{0}','{1}','{2}')",
            pEmpleo.nombre, pEmpleo.idEmpresa, pEmpleo.descripcion), conexion.establecerConxion());
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

        public DataTable listarEmpleos()
        {
            BDComun Conexion = new BDComun();
            MySqlConnection conexion = Conexion.establecerConxion();
            DataTable tabla = new DataTable();
            MySqlDataReader LeerFilas;
            string sql = "ListarEmpleos";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();

            return tabla;
        }

        public DataTable buscarEmpleos(string pBusqueda)
        {
            BDComun Conexion = new BDComun();
            MySqlConnection conexion = Conexion.establecerConxion();
            DataTable tabla = new DataTable();
            MySqlDataReader LeerFilas;
            string sql = "BuscarEmpleos";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@busqueda", pBusqueda);
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();

            return tabla;
        }


        public int ModificarEmpleo(EmpleoEN pEmpleo)
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "UPDATE Empleos SET nombre=@nombre, idEmpresa=@idEmpresa, descripcion=@descripcion WHERE id = @id";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@id", pEmpleo.id);
            comando.Parameters.AddWithValue("@nombre", pEmpleo.nombre);
            comando.Parameters.AddWithValue("@idEmpresa", pEmpleo.idEmpresa);
            comando.Parameters.AddWithValue("@descripcion", pEmpleo.descripcion);
            int resultado = comando.ExecuteNonQuery();
            conexion.Close();
            return resultado;
        }

        public int EliminarEmpleo(Int64 pIdEmpleo)
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM Empleos WHERE id = {0}", pIdEmpleo), conexion);

            int resultado = comando.ExecuteNonQuery();
            conexion.Close();
            return resultado;
        }
    }
}
