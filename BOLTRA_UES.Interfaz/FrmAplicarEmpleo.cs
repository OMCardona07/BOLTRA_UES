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
    public partial class FrmAplicarEmpleo : Form
    {
        public FrmAplicarEmpleo()
        {
            InitializeComponent();
        }

        PostulacionesEN _postulacion = new PostulacionesEN();
        PostulacionesBL _postulacionBL = new PostulacionesBL();

        public void Limpiar()
        {
            txtCodigo.Text = "";
            txtPuesto.Text = "";
            txtIdEmpleo.Text = "";
            txtStatus.Text = "";
        }

        private void ListarEmpleos()
        {
            tablaEmpleos.DataSource = _postulacionBL.ListarEmpleo();
        }

        private void BuscarEmpleos(string pNombre)
        {
            tablaEmpleos.DataSource = _postulacionBL.BuscarEmpleo(pNombre);
        }

        private void FrmAplicarEmpleo_Load(object sender, EventArgs e)
        {
            ListarEmpleos();
        }

        private void tablaEmpleos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdEmpleo.Text = tablaEmpleos.CurrentRow.Cells[0].Value.ToString();
            txtPuesto.Text = tablaEmpleos.CurrentRow.Cells[1].Value.ToString();
            txtStatus.Text = "POSTULADA";
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (txtPuesto.Text != "" && txtIdEmpleo.Text != "")
            {
                _postulacion.idEmpleo = Convert.ToInt32(txtIdEmpleo.Text);
                _postulacion.idAspirante = Convert.ToInt32(Session.id);
                _postulacion.status = txtStatus.Text.ToUpper();
                _postulacionBL.AgregarPostulacion(_postulacion);
                FrmSuccess.confirmacionForm("TE HAS POSTULADO A LA \n" + "OFERTA DE TRABAJO");
                Limpiar();
            }
            else
                FrmError.confirmacionForm("SELECCIONE UNA OFERTA DANDO \n" + "DOBLE CLICK A LA TABLA");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarEmpleos(txtBuscar.Text);
        }
    }
}
