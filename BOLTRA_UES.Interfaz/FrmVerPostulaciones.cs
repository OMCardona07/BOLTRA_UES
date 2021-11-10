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
    public partial class FrmVerPostulaciones : Form
    {
        public FrmVerPostulaciones()
        {
            InitializeComponent();
            tablaPost.DefaultCellStyle.Font = new Font("Poppins", 12, FontStyle.Bold);
            tablaPost.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 14, FontStyle.Bold);
        }

        PostulacionesEN _postulacion = new PostulacionesEN();
        PostulacionesBL _postulacionBL = new PostulacionesBL();
        string Estado;

        private void ListarPostulaciones()
        {
            tablaPost.DataSource = _postulacionBL.ListarPostulaciones(Convert.ToInt32(Session.id));
        }

        private void FrmVerPostulaciones_Load(object sender, EventArgs e)
        {
            ListarPostulaciones();
            cambiarColor();
        }

        private void cambiarColor()
        {

            /*Estado = tablaPost.CurrentRow.Cells[2].Value.ToString();

            if (Estado == "POSTULADA")
            {
                tablaPost.DefaultCellStyle.BackColor = Color.Yellow;
            }
            if (Estado == "EN PROCESO")
            {
                tablaPost.DefaultCellStyle.BackColor = Color.Orange;
            }
            if (Estado == "FINALIZADA")
            {
                tablaPost.DefaultCellStyle.BackColor = Color.Green;
            }*/
        }

        private void tablaPost_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            var codigo = gridView.Rows[0].Cells["ID_POstulacion"].Value.ToString();
            

            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (row.Cells["Estado"].Value.ToString() == "POSTULADA")
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (row.Cells["Estado"].Value.ToString() == "EN PROCESO")
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
                if (row.Cells["Estado"].Value.ToString() == "FINALIZADA")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }
    }
}
