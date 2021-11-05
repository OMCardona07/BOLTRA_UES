using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLTRA_UES.EN
{
    public class AdministradorEN
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dui { get; set; }
        public string fechaN { get; set; }
        public string userN { get; set; }
        public string pass { get; set; }
        public string tipoUser { get; set; }

        public AdministradorEN() { }

        public AdministradorEN(string pNombres, string pApellidos, string pdui, string pFechaN,
            string pUserN, string pPass, string pTipoUser)
        {
            nombres = pNombres;
            apellidos = pApellidos;
            dui = pdui;
            fechaN = pFechaN;
            userN = pUserN;
            pass = pPass;
            tipoUser = pTipoUser;
        }
    }
}
