using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLTRA_UES.EN;
using BOLTRA_UES.DAL;

namespace BOLTRA_UES.BL
{
    public class AdministradorBL
    {
        AdministradorDAL DAL = new AdministradorDAL();
        public int AgregarAdmin(AdministradorEN pAspirante)
        {
            return DAL.AgregarAdmin(pAspirante);
        }

        public int BuscarAdmin(string pUser, string pPass)
        {
            return DAL.BuscarAdmin(pUser, pPass);
        }

        public bool Loging(string pUser, string pPass)
        {
            return DAL.Loging(pUser, pPass);
        }
    }
}
