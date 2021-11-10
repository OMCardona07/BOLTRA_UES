using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLTRA_UES.EN
{
    public class PostulacionesEN
    {
        public Int64 id { get; set; }
        public Int32 idEmpleo { get; set; }
        public Int32 idAspirante { get; set; }
        public string status { get; set; }


        public PostulacionesEN() { }

        public PostulacionesEN(Int64 pId, Int32 pIdEmpleo, Int32 pIdAspirante, string pStatus)
        {
            id = pId;
            idEmpleo = pIdEmpleo;
            idAspirante = pIdAspirante;
            status = pStatus;
        }
    }
}
