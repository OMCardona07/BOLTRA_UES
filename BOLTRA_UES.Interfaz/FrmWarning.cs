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
    public partial class FrmWarning : Form
    {
        public FrmWarning(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        private void FrmWarning_Load(object sender, EventArgs e)
        {
            esclarecerForm.ShowAsyc(this);
            esclarecerForm.Delay = Convert.ToInt32(0.5);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
