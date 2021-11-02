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
#pragma warning disable CS0219 // La variable 'datosUsuario' está asignada pero su valor nunca se usa
            AspiranteEN datosUsuario = null;
#pragma warning restore CS0219 // La variable 'datosUsuario' está asignada pero su valor nunca se usa
            BDComun conexion = new BDComun();
#pragma warning disable CS0168 // La variable 'aspirante' se ha declarado pero nunca se usa
            string aspirante;
#pragma warning restore CS0168 // La variable 'aspirante' se ha declarado pero nunca se usa

            if(txtUser.Text != null && txtUser.Text != null && cbCredencial.Text != null)
            {
                
            }

        }
    }
}
