﻿using System;
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
    public partial class FrmPerfil : Form
    {
        public FrmPerfil()
        {
            InitializeComponent();
        }

        public void llenarTxt()
        {
            txtNombres.Text = Session.nombres;
            txtApellidos.Text = Session.apellidos;
            txtDui.Text = Session.dui;
            dtpFechaN.Text = Session.fechaN;
            txtUserN.Text = Session.userN;
            txtPass.Text = Session.pass;
            txtTipoUser.Text = Session.tipoUser;
            cbGenero.Text = Session.genero;
            cbEstadoC.Text = Session.estadoC;
            txtTelefono.Text = Session.telefono;
            txtDireccion.Text = Session.direccion;
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
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            inhabilitarTxt();
            llenarTxt();
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

                _aspiranteBL.ModificarAspirante(_aspirante);
                FrmSuccess.confirmacionForm("EL PERFIL FUE \n" + "MODIFICADO CON EXITO");
            }
            else
            {
                FrmError.confirmacionForm("LLENE TODOS LOS CAMPOS");
            }
        }
    }
}