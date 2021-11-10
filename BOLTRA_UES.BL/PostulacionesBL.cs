using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLTRA_UES.DAL;
using BOLTRA_UES.EN;

namespace BOLTRA_UES.BL
{
    public class PostulacionesBL
    {
        PostulacionesDAL DAL = new PostulacionesDAL();
        public int AgregarPostulacion(PostulacionesEN pPostulacion)
        {
            return DAL.AgregarPostulacion(pPostulacion);
        }

        public DataTable BuscarEmpleo(string pBusqueda)
        {
            return DAL.buscarEmpleos(pBusqueda);
        }

        public DataTable ListarEmpleo()
        {
            return DAL.listarEmpleos();
        }
    }
}
