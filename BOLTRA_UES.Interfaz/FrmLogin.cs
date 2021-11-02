using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLTRA_UES.EN;
using BOLTRA_UES.BL;
using BOLTRA_UES.DAL;

namespace BOLTRA_UES.Interfaz
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        AspiranteEN _aspirante = new AspiranteEN();
        AspiranteBL _aspiranteBL = new AspiranteBL();

        private void btnRegistroA_Click(object sender, EventArgs e)
        {
            FrmRegistroA frm = new FrmRegistroA();
            this.Hide();
            frm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AspiranteEN datosUsuario = null;
            BDComun conexion = new BDComun();
            string aspirante;

            if(txtUser.Text != null && txtUser.Text != null && cbCredencial.Text != null)
            {
                
            }

        }
    }
}
