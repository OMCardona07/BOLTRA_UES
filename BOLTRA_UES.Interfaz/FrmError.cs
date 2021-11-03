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
    public partial class FrmError : Form
    {
        public FrmError(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        private void FrmError_Load(object sender, EventArgs e)
        {
            esclarecerForm.ShowAsyc(this);
            esclarecerForm.Delay = Convert.ToInt32(0.5);
        }

        public static void confirmacionForm(string mensaje)
        {
            FrmError frm = new FrmError(mensaje);
            frm.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
