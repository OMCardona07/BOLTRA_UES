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
            //PantallaOK();
            lblUserName.Text = Session.userN;
            lblBienvenida.Text = Session.userN + " " + "\nBIENVENIDO AL SISTEMA BOLTRA";
        }

        //Metodo para que el boton se mantenga en un color mientras este seleccionado
        public void BotonSelect(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            btnEmpresas.Textcolor = Color.White;
            btnEmpleos.Textcolor = Color.White;
            btnSeguimiento.Textcolor = Color.White;

            sender.selected = true;

            if (sender.selected)
            {
                sender.Textcolor = Color.FromArgb(255, 92, 92);
            }
        }

        //Metodo para que la flecha del menu se mueba al boton seleccionado
        private void SeguirBoton(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            flecha.Top = sender.Top;
        }

        private Form formActivado = null;

        private void AbrirFormularioEnWrapper(Form FormHijo)
        {
            if (formActivado != null)
            {
                formActivado.Close();
            }

            formActivado = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.Dock = DockStyle.Fill;
            wrapper.Controls.Add(FormHijo);
            wrapper.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            BotonSelect((Bunifu.Framework.UI.BunifuFlatButton)sender);
            SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmEmpresa());
        }

        private void btnEmpleos_Click(object sender, EventArgs e)
        {
            BotonSelect((Bunifu.Framework.UI.BunifuFlatButton)sender);
            SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmEmpleo());
        }

        private void btnSeguimiento_Click(object sender, EventArgs e)
        {
            BotonSelect((Bunifu.Framework.UI.BunifuFlatButton)sender);
            SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmSeguimiento());
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            FrmLogin login = new FrmLogin();
            Form mensaje = new FrmWarning("¿ESTA SEGURO QUE QUIERE\n" + "CERRAR SESION");
            resultado = mensaje.ShowDialog();
            
            if (resultado == DialogResult.OK)
            {
                this.Hide();
                login.ShowDialog();
            }
        } 
    }
}
