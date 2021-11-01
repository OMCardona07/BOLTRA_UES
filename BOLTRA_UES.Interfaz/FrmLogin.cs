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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnRegistroA_Click(object sender, EventArgs e)
        {
            FrmRegistroA frm = new FrmRegistroA();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
