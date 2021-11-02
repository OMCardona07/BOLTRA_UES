using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLTRA_UES.EN
{
   public class EmpresasEN
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string rubro { get; set; }
        public string descripcion { get; set; }
        

        public EmpresasEN() { }

        public EmpresasEN(Int64 pId, string pNombre, string pRubro, string pDescripcion)
        {
            id = pId;
            nombre = pNombre;
            rubro = pRubro;
            descripcion = pDescripcion;
        }
    }
}
