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
    }
}
