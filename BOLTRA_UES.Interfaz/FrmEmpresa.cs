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
    public partial class FrmEmpresa : Form
    {
        
        public FrmEmpresa()
        {
            InitializeComponent();
        }

        EmpresasEN _empresa = new EmpresasEN();
        EmpresasBL _empresasBL = new EmpresasBL();

        string nombre, rubro, descripcion;
        int id = 0;
        public string idEmpresa;
        int renglon = 0;

        string nombreE, rubroE, descripcionE;
        int idE = 0;


        public void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtRubro.Text = "";
            txtDescripcion.Text = "";
        }

        public void inhabilitarTxt()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtRubro.Enabled = false;
            txtDescripcion.Enabled = false;
        }

        public void habilitarTxt()
        {
            txtNombre.Enabled = true;
            txtRubro.Enabled = true;
            txtDescripcion.Enabled = true;
        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            Buscar(" ");
            txtCodigo.Enabled = false;
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Buscar(txtBuscar.Text);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaEmpresas.SelectedRows.Count > 0)
            {
                txtCodigo.Text = tablaEmpresas.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = tablaEmpresas.CurrentRow.Cells[1].Value.ToString();
                txtRubro.Text = tablaEmpresas.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tablaEmpresas.CurrentRow.Cells[3].Value.ToString();
                
            }
            else
            {
                FrmError.confirmacionForm("SELECCIONE LA FILA A EDITAR");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaEmpresas.SelectedRows.Count > 0)
            {
                _empresa.id = Convert.ToInt32(tablaEmpresas.CurrentRow.Cells[0].Value.ToString());

                DialogResult resultado = new DialogResult();
                Form mensaje = new FrmWarning("¿ESTA SEGURO QUE QUIERE\n" + "ELIMINAR EL REGISTRO?");
                resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _empresasBL.EliminarEmpresa(_empresa.id);
                    Buscar("");
                }
                
            }
            else
            {
                FrmError.confirmacionForm("SELECCIONE LA FILA A EDITAR");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtRubro.Text != "" && txtDescripcion.Text != "")
            {
                _empresa.nombre = txtNombre.Text.ToUpper();
                _empresa.rubro = txtRubro.Text.ToUpper();
                _empresa.descripcion = txtDescripcion.Text.ToUpper();

                _empresasBL.ModificarEmpresa(_empresa);
                FrmSuccess.confirmacionForm("EL PERFIL FUE \n" + "MODIFICADO CON EXITO");
                Limpiar();
                
            }
            else
            {
                FrmError.confirmacionForm("LLENE TODOS LOS CAMPOS");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtRubro.Text != "" && txtDescripcion.Text != "")
            {
                _empresa.nombre = txtNombre.Text.ToUpper();
                _empresa.rubro = txtRubro.Text.ToUpper();
                _empresa.descripcion = txtDescripcion.Text.ToUpper();
                _empresasBL.AgregarEmpresa(_empresa);
                FrmSuccess.confirmacionForm("LA EMPRESA FUE \n" + "REGISTRADA CON EXITO");
                Limpiar();
                Buscar("");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text);
        }

        private void LlenarData()
        {
            BDComun conexion = new BDComun();
            MySqlCommand query = new MySqlCommand();

            query.CommandText = "SELECT * FROM empresas";
            MySqlDataReader consultar;
            query.Connection = conexion.establecerConxion();
            consultar = query.ExecuteReader();

            while (consultar.Read())
            {
                id = consultar.GetInt32(0);
                nombre = consultar.GetString(1);
                rubro = consultar.GetString(2);
                descripcion = consultar.GetString(3);
                tablaEmpresas.Rows.Add(Convert.ToString(id), nombre, rubro, descripcion);
            }
        }

        private void Buscar(string pNombre)
        {
            tablaEmpresas.DataSource = _empresasBL.ListarEmpresas(pNombre);
        }
    }
}
