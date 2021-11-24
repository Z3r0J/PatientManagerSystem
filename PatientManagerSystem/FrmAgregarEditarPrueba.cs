﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer.Modelos;
namespace PatientManagerSystem
{
    public partial class FrmAgregarEditarPrueba : Form
    {
        ServicePruebasLaboratorio _servicioPruebas;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public int id;
        public FrmAgregarEditarPrueba()
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioPruebas = new ServicePruebasLaboratorio(_conexion);
            id = 0;

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            PruebasLaboratorios prueba = new PruebasLaboratorios();
            prueba.Id = id;
            prueba.Nombre = txtPrueba.Text.Trim();

            bool resultado = false;

            if(prueba.Nombre == "")
            {
                MessageBox.Show("El campo nombre no puede estar vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensajeBien = "", mensajeError = "";

            if (id <= 0)
            {
               resultado = _servicioPruebas.CrearPrueba(prueba);
                mensajeBien = "creado";
                mensajeError = "crear";
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Esta seguro de que desea editar la prueba?", "Advertencia", MessageBoxButtons.YesNo))
                {
                    resultado = _servicioPruebas.EditarPrueba(prueba);
                    mensajeBien = "editado";
                    mensajeError = "editar";
                }
                else
                {
                    return;
                }
            }

            if (resultado)
            {
                MessageBox.Show($"Se ha {mensajeBien} la prueba con exito.");
            }
            else
            {
                MessageBox.Show($"Error al {mensajeError} la prueba.");

            }
        }

    }
}
