using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLTRA_UES.DAL;
using BOLTRA_UES.EN;
using MySql.Data.MySqlClient;

namespace BOLTRA_UES.Interfaz
{
    public partial class FrmPrincipalA : Form
    {
        public FrmPrincipalA()
        {
            InitializeComponent();
            obtenerNombreUsuario();
        }

        AspiranteEN _aspirante = new AspiranteEN();

        //Metodo para colocar el formulario en pantalla completa y sin utilizar la zona de barra de tareas
        public void PantallaOK()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        public void obtenerNombreUsuario()
        {
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "SELECT * FROM Aspirante WHERE idA= @idA";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@idA", Session.id);
            reader = comando.ExecuteReader();

            if (reader.Read())
            {
                lblUserName.Text = reader["userN"].ToString();
                lblBienvenida.Text = reader["userN"].ToString() + " " + "\nBIENVENIDO AL SISTEMA BOLTRA";
            }
        }

        private void FrmPrincipalA_Load(object sender, EventArgs e)
        {
            obtenerNombreUsuario();
            //lblUserName.Text = Session.userN;
            //lblBienvenida.Text = Session.userN + " " + "\nBIENVENIDO AL SISTEMA BOLTRA";
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
            AbrirFormularioEnWrapper(new FrmPerfil());
        }
        //-----------------------------------------------------------------//

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
