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
    public class EmpleoBL
    {
        EmpleoDAL DAL = new EmpleoDAL();
        public int AgregarEmpleo(EmpleoEN pEmpleo)
        {
            return DAL.AgregarEmpleo(pEmpleo);
        }

        public DataTable BuscarEmpleo(string pBusqueda)
        {
            return DAL.buscarEmpleos( pBusqueda);
        }

        public DataTable ListarEmpleo()
        {
            return DAL.listarEmpleos();
        }

        public int ModificarEmpleo(EmpleoEN pEmpleo)
        {
            return DAL.ModificarEmpleo(pEmpleo);
        }

        public int EliminarEmpleo(Int64 pId)
        {
            return DAL.EliminarEmpleo(pId);
        }
    }
}
