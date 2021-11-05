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
    public partial class FrmSuccess : Form
    {
        public FrmSuccess(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        private void FrmSuccess_Load(object sender, EventArgs e)
        {
            esclarecerForm.ShowAsyc(this);
            esclarecerForm.Delay = Convert.ToInt32(0.5);
        }

        public static void confirmacionForm(string mensaje)
        {
            FrmSuccess frm = new FrmSuccess(mensaje);
            frm.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
