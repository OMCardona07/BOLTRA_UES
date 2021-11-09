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
    }
}
