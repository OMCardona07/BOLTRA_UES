using BOLTRA_UES.BL;
using BOLTRA_UES.EN;
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
    public partial class FrmRegistroA : Form
    {
#pragma warning disable CS0414 // El campo 'FrmRegistroA.dui' está asignado pero su valor nunca se usa
        string dui = "";
#pragma warning restore CS0414 // El campo 'FrmRegistroA.dui' está asignado pero su valor nunca se usa
#pragma warning disable CS0414 // El campo 'FrmRegistroA.tel' está asignado pero su valor nunca se usa
        string tel = "";
#pragma warning restore CS0414 // El campo 'FrmRegistroA.tel' está asignado pero su valor nunca se usa
        public FrmRegistroA()
        {
            InitializeComponent();
        }


        private void FrmRegistroA_Load(object sender, EventArgs e)
        {
            /*txtDui.Text = "12345678-9";
            txtNombres.ForeColor = Color.Gray;
            txtTelefono.Text = "0000-0000";
            txtPass.ForeColor = Color.Gray;*/
        }

        private void txtDui_Enter(object sender, EventArgs e)
        {
            /*txtDui.Text = "";
            txtDui.ForeColor = Color.Black;*/
        }

        private void txtDui_Leave(object sender, EventArgs e)
        {
            /*dui = txtDui.Text;
            if (dui.Equals("12345678-9"))
            {
                txtDui.Text = "12345678-9";
                txtDui.ForeColor = Color.Gray;

            }
            else
            {
                if (dui.Equals(""))
                {

                    txtDui.Text = "12345678-9";
                    txtDui.ForeColor = Color.Gray;
                }
                else
                {
                    txtDui.Text = dui;
                    txtDui.ForeColor = Color.Black;
                }
            }*/
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            /*txtTelefono.Text = "";
            txtTelefono.ForeColor = Color.Black;*/
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            /*tel = txtTelefono.Text;
            if (tel.Equals("0000-0000"))
            {
                txtTelefono.Text = "0000-0000";
                txtTelefono.ForeColor = Color.Gray;

            }
            else
            {
                if (tel.Equals(""))
                {

                    txtTelefono.Text = "0000-0000";
                    txtTelefono.ForeColor = Color.Gray;
                }
                else
                {
                    txtTelefono.Text = dui;
                    txtTelefono.ForeColor = Color.Black;
                }
            }*/
        }


        AspiranteEN _aspirante = new AspiranteEN();
        AspiranteBL _aspiranteBL = new AspiranteBL();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text != "" && txtApellidos.Text != "" && txtDui.Text != "" && txtUserN.Text != ""
                && txtPass.Text != "" && cbGenero.Text != "" && cbEstadoC.Text != "" && txtTelefono.Text != "" && txtDireccion.Text != "")
            {
                _aspirante.nombres = txtNombres.Text;
                _aspirante.apellidos = txtApellidos.Text;
                _aspirante.dui = txtDui.Text;
                _aspirante.fechaN = dtpFechaN.Value.ToShortDateString();
                _aspirante.userN = txtUserN.Text;
                _aspirante.pass = txtPass.Text;
                _aspirante.tipoUser = txtTipoU.Text;
                _aspirante.genero = cbGenero.Text;
                _aspirante.estadoC = cbEstadoC.Text;
                _aspirante.telefono = txtTelefono.Text;
                _aspirante.direccion = txtDireccion.Text;

                _aspiranteBL.AgregarAspirante(_aspirante);
            }
            else
            {
                FrmError.confirmacionForm("LLENE TODOS LOS CAMPOS");
            }
        }
    }
}
