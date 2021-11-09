using System;
using System.Collections.Generic;
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
    }
}
