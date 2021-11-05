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
        int renglon = 0;

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
            Obtener();
            inhabilitarTxt();
        }

        private void tablaEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            renglon = e.RowIndex;
        }

        private void tablaEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre, rubro, descripcion, id;

            id = tablaEmpresas.Rows[renglon].Cells["Codigo"].Value.ToString();
            nombre = tablaEmpresas.Rows[renglon].Cells["NombreEmpresa"].Value.ToString();
            rubro = tablaEmpresas.Rows[renglon].Cells["RubroEmpresa"].Value.ToString();
            descripcion = tablaEmpresas.Rows[renglon].Cells["DescripcionE"].Value.ToString();

            txtCodigo.Text = id;
            txtNombre.Text = nombre;
            txtRubro.Text = rubro;
            txtDescripcion.Text = descripcion;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarTxt();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtRubro.Text != "" && txtDescripcion.Text != "")
            {
                _empresa.nombre = txtNombre.Text;
                _empresa.rubro = txtRubro.Text;
                _empresa.descripcion = txtDescripcion.Text;
                _empresasBL.AgregarEmpresa(_empresa);
                FrmSuccess.confirmacionForm("LA EMPRESA FUE \n" + "REGISTRADA CON EXITO");
            }

        }

        private void Obtener()
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

        
    }
}
