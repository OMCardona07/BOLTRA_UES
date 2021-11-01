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
    }
}
