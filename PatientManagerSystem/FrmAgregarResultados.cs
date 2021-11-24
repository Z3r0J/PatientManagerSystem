using System;
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
    public partial class FrmAgregarResultados : Form
    {
        private ServiceResultadosLab _resultadosLab;

        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public int Id { get; set; }
        public FrmAgregarResultados()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection(connectionString);
            _resultadosLab = new ServiceResultadosLab(conexion);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Maximizar_vlogin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Maximizar_vlogin.Visible = false;
            Restaurar_vlogin.Visible = true;
        }

        private void Restaurar_vlogin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Restaurar_vlogin.Visible = false;
            Maximizar_vlogin.Visible = true;
        }

        private void Btn_Reportar_Click(object sender, EventArgs e)
        {
            Reportar();

        }
        private void Reportar()
        {

                if (string.IsNullOrEmpty(TxtResultado.Text))
                {
                    MessageBox.Show("Debe insertar el resultado de la prueba", "Advertencia");
                }
                else
                {
                ResultadosLaboratorios resultados = new ResultadosLaboratorios()
                {
                    Id = Id,
                    Resultados = TxtResultado.Text,
                    Estado = 2

                };


                bool res = _resultadosLab.ReportarResultados(resultados);

                if (res)
                {
                    MessageBox.Show("Se reporto el resultado correctamente!","Notificacion");
                }
                else
                {
                    MessageBox.Show("Oops, Ocurrio un error!", "Notificacion");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
