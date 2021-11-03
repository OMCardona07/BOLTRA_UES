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


namespace BOLTRA_UES.Interfaz
{
    public partial class FrmEmpresa : Form
    {
        public FrmEmpresa()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        EmpresasEN _empresa = new EmpresasEN();
        EmpresasBL _empresasBL = new EmpresasBL();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtRubro.Text != "" && txtDescripcion.Text != "")
            {
                _empresa.nombre = txtNombre.Text;
                _empresa.rubro = txtRubro.Text;
                _empresa.descripcion = txtDescripcion.Text;
                _empresasBL.AgregarEmpresa(_empresa);
                MessageBox.Show("La empresa fue registrada con exito");
            }

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
