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
    public partial class FrmPrincipalA : Form
    {
        public FrmPrincipalA()
        {
            InitializeComponent();
        }

        AspiranteEN _aspirante = new AspiranteEN();

        //Metodo para colocar el formulario en pantalla completa y sin utilizar la zona de barra de tareas
        public void PantallaOK()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void FrmPrincipalA_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            lblUserName.Text = Session.userN;
        }

        //Metodo para que el boton se mantenga en un color mientras este seleccionado
        public void BotonSelect(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            btnBuscarOfer.Textcolor = Color.White;
            btnPerfil.Textcolor = Color.White;
            btnPostulacion.Textcolor = Color.White;

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
        //--------------- METODOS CLICK PARA CADA BOTON DEL MENU------------//
        private void btnBuscarOfer_Click(object sender, EventArgs e)
        {
            BotonSelect((Bunifu.Framework.UI.BunifuFlatButton)sender);
            SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmBuscarOfer());
        }

        private void btnPostulacion_Click(object sender, EventArgs e)
        {
            BotonSelect((Bunifu.Framework.UI.BunifuFlatButton)sender);
            SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            BotonSelect((Bunifu.Framework.UI.BunifuFlatButton)sender);
            SeguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }
        //-----------------------------------------------------------------//

        private Form formActivado = new FrmBuscarOfer();

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Form mensaje = new FrmWarning("¿ESTA SEGURO QUE QUIERE\n" + "SALIR DE LA APLICACION?");
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Application.Exit();
                this.Hide();
            }
        }
    }
}
