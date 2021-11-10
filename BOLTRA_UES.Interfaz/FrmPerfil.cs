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
using MySql.Data.MySqlClient;

namespace BOLTRA_UES.Interfaz
{
    public partial class FrmPerfil : Form
    {
        public FrmPerfil()
        {
            InitializeComponent();
        }

        public void llenarTxt()
        {
            txtId.Text = Convert.ToString(Session.id);
            BDComun Conexion = new BDComun();

            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.establecerConxion();
            //conexion.Open();

            string sql = "SELECT * FROM Aspirante WHERE idA= @idA";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@idA", txtId.Text);
            reader = comando.ExecuteReader();

            if (reader.Read())
            {
                txtNombres.Text = reader["nombres"].ToString();
                txtApellidos.Text = reader["apellidos"].ToString();
                txtDui.Text = reader["dui"].ToString();
                dtpFechaN.Text = reader["fechaN"].ToString();
                txtUserN.Text = reader["userN"].ToString();
                txtPass.Text = reader["pass"].ToString();
                txtTipoUser.Text = reader["tipoUser"].ToString();
                cbGenero.Text = reader["genero"].ToString();
                cbEstadoC.Text = reader["estadoC"].ToString();
                txtTelefono.Text = reader["telefono"].ToString();
                txtDireccion.Text = reader["direccion"].ToString();
            }
        }

        public void inhabilitarTxt()
        {
            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;
            txtDui.Enabled = false;
            dtpFechaN.Enabled = false;
            txtUserN.Enabled = false;
            txtPass.Enabled = false;
            txtTipoUser.Enabled = false;
            cbGenero.Enabled = false;
            cbEstadoC.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
        }

        public void habilitarTxt()
        {
            txtNombres.Enabled = true;
            txtApellidos.Enabled = true;
            txtDui.Enabled = true;
            dtpFechaN.Enabled = true;
            txtUserN.Enabled = true;
            txtPass.Enabled = true;
            cbGenero.Enabled = true;
            cbEstadoC.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            txtNombres.Focus();
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            inhabilitarTxt();
            llenarTxt();
            txtId.Enabled = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            habilitarTxt();
        }

        AspiranteEN _aspirante = new AspiranteEN();
        AspiranteBL _aspiranteBL = new AspiranteBL();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text != "" && txtApellidos.Text != "" && txtDui.Text != "" && txtUserN.Text != ""
               && txtPass.Text != "" && cbGenero.Text != "" && cbEstadoC.Text != "" && txtTelefono.Text != "" && txtDireccion.Text != "")
            {
                _aspirante.id = Convert.ToInt64(txtId.Text);
                _aspirante.nombres = txtNombres.Text;
                _aspirante.apellidos = txtApellidos.Text;
                _aspirante.dui = txtDui.Text;
                _aspirante.fechaN = dtpFechaN.Value.ToShortDateString();
                _aspirante.userN = txtUserN.Text;
                _aspirante.pass = txtPass.Text;
                _aspirante.tipoUser = txtTipoUser.Text;
                _aspirante.genero = cbGenero.Text;
                _aspirante.estadoC = cbEstadoC.Text;
                _aspirante.telefono = txtTelefono.Text;
                _aspirante.direccion = txtDireccion.Text;

                if (_aspirante.id != 0)
                {
                    _aspiranteBL.ModificarAspirante(_aspirante);
                    FrmSuccess.confirmacionForm("EL PERFIL FUE \n" + "MODIFICADO CON EXITO");
                    inhabilitarTxt();
                    llenarTxt();
                    
                }    
            }
            else
            {
                FrmError.confirmacionForm("LLENE TODOS LOS CAMPOS");
            }
        }
    }
}
