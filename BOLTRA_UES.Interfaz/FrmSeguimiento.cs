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

namespace BOLTRA_UES.Interfaz
{
    public partial class FrmSeguimiento : Form
    {
        public FrmSeguimiento()
        {
            InitializeComponent();
            tablaEmpleos.DefaultCellStyle.Font = new Font("Poppins", 9);
            tablaEmpleos.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 9, FontStyle.Bold);
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtPuesto.Text = "";
            txtAspirante.Text = "";
            cbEstado.Text = "";
        }

        private void Inhabilitar()
        {
            txtCodigo.Enabled = false;
            txtPuesto.Enabled = false;
            txtAspirante.Enabled = false;
        }

        PostulacionesBL _postulacionBL = new PostulacionesBL();
        PostulacionesEN _postulacion = new PostulacionesEN();

        private void ListarPostulaciones()
        {
            tablaEmpleos.DataSource = _postulacionBL.ListarPostulacionesAdmin();
        }

        private void FrmSeguimiento_Load(object sender, EventArgs e)
        {
            ListarPostulaciones();
            Inhabilitar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _postulacion.id = Convert.ToInt64(txtCodigo.Text);
            _postulacion.status = cbEstado.Text.ToUpper();

            if (_postulacion.id != 0)
            {
                _postulacionBL.CambiarEstado(_postulacion);
                FrmSuccess.confirmacionForm("HA MODIFICADO EL ESTADO \n" + "DE LA POSTULACION");
                Limpiar();
                ListarPostulaciones();
            }
        }

        private void tablaEmpleos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = tablaEmpleos.CurrentRow.Cells[0].Value.ToString();
            txtPuesto.Text = tablaEmpleos.CurrentRow.Cells[1].Value.ToString();
            txtAspirante.Text = tablaEmpleos.CurrentRow.Cells[2].Value.ToString();
            cbEstado.Text = tablaEmpleos.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
