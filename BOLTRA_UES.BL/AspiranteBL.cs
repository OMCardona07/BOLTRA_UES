using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLTRA_UES.DAL;
using BOLTRA_UES.EN;

namespace BOLTRA_UES.BL
{
    public class AspiranteBL
    {
        AspiranteDAL DAL = new AspiranteDAL();
        public int AgregarAspirante(AspiranteEN pAspirante)
        {
            return DAL.AgregarAspirante(pAspirante);
        }

        public int BuscarAspirante(string usuario)
        {
            return DAL.ObtenerPorUsuario(usuario);
        }
    }
}
