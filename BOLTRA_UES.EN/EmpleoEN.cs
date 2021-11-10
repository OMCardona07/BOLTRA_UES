using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLTRA_UES.EN
{
    public class EmpleoEN
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public int idEmpresa { get; set; }
        public string descripcion { get; set; }


        public EmpleoEN() { }

        public EmpleoEN(Int64 pId, string pNombre, int pIdEmpresa, string pDescripcion)
        {
            id = pId;
            nombre = pNombre;
            idEmpresa = pIdEmpresa;
            descripcion = pDescripcion;
        }
    }
}
