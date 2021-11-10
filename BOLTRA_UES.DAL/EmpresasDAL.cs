using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLTRA_UES.EN;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BOLTRA_UES.DAL
{
    public  class EmpresasDAL
    {
        public int AgregarEmpresa(EmpresasEN pEmpresa)
        {
            BDComun conexion = new BDComun();
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO empresas (Nombre, Rubro, Descripcion) VALUES('{0}','{1}','{2}')",
            pEmpresa.nombre, pEmpresa.rubro, pEmpresa.descripcion), conexion.establecerConxion());
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

        public List<EmpresasEN> ListarEmpresas(string pNombre)
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader LeerFilas;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();
            string sql = "SELECT * FROM  empresas WHERE Nombre LIKE CONCAT('%', @nombre, '%')";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@nombre", pNombre);
            LeerFilas = comando.ExecuteReader();

            List<EmpresasEN> _listaEmpresas = new List<EmpresasEN>();

            while (LeerFilas.Read())
            {
                _listaEmpresas.Add(new EmpresasEN
                {
                    id = LeerFilas.GetInt64(0),
                    nombre = LeerFilas.GetString(1),
                    rubro = LeerFilas.GetString(2),
                    descripcion = LeerFilas.GetString(3),
                });

            }
            LeerFilas.Close();
            return _listaEmpresas;
        }

        public int BuscarEmpresa(string pNombre)
        {
            int resultado;
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "SELECT * FROM empresas WHERE Nombre= @nombre";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@nombre", pNombre);
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

        public int ModificarEmpresa(EmpresasEN pAspirante)
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "UPDATE empresas SET Nombre=@nombre, Rubro=@rubro, Descripcion=@descripcion WHERE id = @id";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@id", pAspirante.id);
            comando.Parameters.AddWithValue("@nombre", pAspirante.nombre);
            comando.Parameters.AddWithValue("@rubro", pAspirante.rubro);
            comando.Parameters.AddWithValue("@descripcion", pAspirante.descripcion);
            int resultado = comando.ExecuteNonQuery();
            conexion.Close();
            return resultado;
        }

        public int EliminarEmpresa(Int64 pidEmpresa)
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM empresas WHERE id = {0}",pidEmpresa), conexion);

            int resultado = comando.ExecuteNonQuery();
            conexion.Close();
            return resultado;
        }
    }
}
