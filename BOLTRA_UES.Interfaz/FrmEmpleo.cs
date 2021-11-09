using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLTRA_UES.BL;
using BOLTRA_UES.EN;
using BOLTRA_UES.DAL;
using MySql.Data.MySqlClient;

namespace BOLTRA_UES.Interfaz
{
    public partial class FrmEmpleo : Form
    {
        public FrmEmpleo()
        {
            InitializeComponent();
        }

        /*int id;
        string nombre, rubro, descripcion;*/


        public void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }

        public void inhabilitarTxt()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
        }

        public void habilitarTxt()
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
        }

        EmpleoBL _empleoBL = new EmpleoBL();
        EmpleoEN _empleo = new EmpleoEN();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != ""  && txtDescripcion.Text != "")
            {
                _empleo.nombre = txtNombre.Text.ToUpper();
                _empleo.idEmpresa = Convert.ToInt32(cbEmpresas.SelectedValue);
                _empleo.descripcion = txtDescripcion.Text.ToUpper();
                _empleoBL.AgregarEmpleo(_empleo);
                FrmSuccess.confirmacionForm("LA EMPRESA FUE \n" + "REGISTRADA CON EXITO");
                Limpiar();
            }
        }

        private void FrmEmpleo_Load(object sender, EventArgs e)
        {
            LlenarData();
        }

        private void LlenarData()
        {
            BDComun conexion = new BDComun();

            MySqlCommand cm = new MySqlCommand("SELECT * FROM empresas", conexion.establecerConxion());

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();

            da.Fill(dt);

            cbEmpresas.ValueMember = "id";
            cbEmpresas.DisplayMember = "nombre";
            cbEmpresas.Items.Insert(0, "--SELECCIONE UNA EMPRESA--");

            cbEmpresas.DataSource = dt;
        }
    }
}
