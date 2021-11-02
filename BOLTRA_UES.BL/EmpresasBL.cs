using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLTRA_UES.DAL;
using BOLTRA_UES.EN;

namespace BOLTRA_UES.BL
{
  public class EmpresasBL
    {
        EmpresasDAL DAL = new EmpresasDAL();
        public int AgregarEmpresa(EmpresasEN pEmpresa)
        {
            return DAL.AgregarEmpresa(pEmpresa);
        }
    }
}
