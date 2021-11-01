using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOLTRA_UES.Interfaz
{
    public partial class FrmPrincipalAdmin : Form
    {
        public FrmPrincipalAdmin()
        {
            InitializeComponent();
        }

        //Metodo para colocar el formulario en pantalla completa y sin utilizar la zona de barra de tareas
        public void PantallaOK()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void FrmPrincipalAdmin_Load(object sender, EventArgs e)
        {
            PantallaOK();
        }

        //Metodo para que la flecha del menu se mueba al boton seleccionado
        private void SeguirBoton(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            flecha.Top = sender.Top;
        }
    }
}
