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
            tablaEmpleos.DefaultCellStyle.Font = new Font("Poppins", 9);
            tablaEmpleos.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 9, FontStyle.Bold);
            txtNombre.Focus();
        }

        


        public void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
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
                ListarEmpleos();
            }
        }

        private void FrmEmpleo_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
            LlenarData();
            ListarEmpleos();
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
            cbEmpresas.SelectedIndex = 0;

            cbEmpresas.DataSource = dt;
        }

        private void ListarEmpleos()
        {
            tablaEmpleos.DataSource = _empleoBL.ListarEmpleo();
        }

        private void BuscarEmpleos(string pNombre)
        {
            tablaEmpleos.DataSource = _empleoBL.BuscarEmpleo(pNombre);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarEmpleos(txtBuscar.Text);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaEmpleos.SelectedRows.Count > 0)
            {
                txtCodigo.Text = tablaEmpleos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = tablaEmpleos.CurrentRow.Cells[1].Value.ToString();
                cbEmpresas.Text = tablaEmpleos.CurrentRow.Cells[3].Value.ToString();
                label1.Text = tablaEmpleos.CurrentRow.Cells[3].Value.ToString();
                txtDescripcion.Text = tablaEmpleos.CurrentRow.Cells[4].Value.ToString();

            }
            else
            {
                FrmError.confirmacionForm("SELECCIONE LA FILA A EDITAR");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != ""  && txtDescripcion.Text != "")
            {
                _empleo.id = Convert.ToInt64(txtCodigo.Text);
                _empleo.nombre = txtNombre.Text.ToUpper();
                _empleo.idEmpresa = Convert.ToInt32(cbEmpresas.SelectedValue);
                _empleo.descripcion = txtDescripcion.Text.ToUpper();

                if(_empleo.id != 0)
                {
                    _empleoBL.ModificarEmpleo(_empleo);
                    FrmSuccess.confirmacionForm("EL PERFIL FUE \n" + "MODIFICADO CON EXITO");
                    Limpiar();
                    ListarEmpleos();
                }
            }
            else
            {
                FrmError.confirmacionForm("LLENE TODOS LOS CAMPOS");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaEmpleos.SelectedRows.Count > 0)
            {
                _empleo.id = Convert.ToInt32(tablaEmpleos.CurrentRow.Cells[0].Value.ToString());

                DialogResult resultado = new DialogResult();
                Form mensaje = new FrmWarning("¿ESTA SEGURO QUE QUIERE\n" + "ELIMINAR EL REGISTRO?");
                resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _empleoBL.EliminarEmpleo(_empleo.id);
                    ListarEmpleos();
                }

            }
            else
            {
                FrmError.confirmacionForm("SELECCIONE LA FILA A EDITAR");
            }
        }
    }
}
