﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLTRA_UES.EN;
using MySql.Data.MySqlClient;

namespace BOLTRA_UES.DAL
{
    public class PostulacionesDAL
    {
        public int AgregarPostulacion(PostulacionesEN pPostulacion)
        {
            BDComun conexion = new BDComun();
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO Postulaciones (idEmpleo, idAspirante, status) VALUES('{0}','{1}','{2}')",
            pPostulacion.idEmpleo, pPostulacion.idAspirante, pPostulacion.status), conexion.establecerConxion());
            retorno = comando.ExecuteNonQuery();
            try
            {
                return retorno;
            }

            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error inesperado" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return retorno;
            }
        }

        public DataTable listarEmpleos()
        {
            BDComun Conexion = new BDComun();
            MySqlConnection conexion = Conexion.establecerConxion();
            DataTable tabla = new DataTable();
            MySqlDataReader LeerFilas;
            string sql = "ListarEmpleosAspirante";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();

            return tabla;
        }

        public DataTable buscarEmpleos(string pBusqueda)
        {
            BDComun Conexion = new BDComun();
            MySqlConnection conexion = Conexion.establecerConxion();
            DataTable tabla = new DataTable();
            MySqlDataReader LeerFilas;
            string sql = "BuscarEmpleosAspirante";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@busqueda", pBusqueda);
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();

            return tabla;
        }
    }
}
