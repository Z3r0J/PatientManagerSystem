using BusinessLayer;
using DataLayer.Modelos;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmAgregarResultados : Form
    {
        #region Variables & Instancia

        private ServiceResultadosLab _resultadosLab;

        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public int Id { get; set; }

        #endregion
        public FrmAgregarResultados()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection(connectionString);
            _resultadosLab = new ServiceResultadosLab(conexion);
        }
        #region Eventos
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_Reportar_Click(object sender, EventArgs e)
        {
            Reportar();

        }
        #endregion

        #region Metodos
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
                    MessageBox.Show("Se reporto el resultado correctamente!", "Notificacion");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Oops, Ocurrio un error!", "Notificacion");
                }
            }
        }

        #endregion
    }
}
