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

        public int BuscarEmpresa(string pNombre)
        {
            return DAL.BuscarEmpresa(pNombre);
        }

        public List<EmpresasEN> ListarEmpresas(string pNombre)
        {
            return DAL.ListarEmpresas(pNombre);
        }

        public int ModificarEmpresa(EmpresasEN pAspirante)
        {
            return DAL.ModificarEmpresa(pAspirante);
        }

        public int EliminarEmpresa(Int64 pId)
        {
            return DAL.EliminarEmpresa(pId);
        }
    }
}
