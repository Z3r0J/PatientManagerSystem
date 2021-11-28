using BusinessLayer;
using DataLayer.Modelos;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace PatientManagerSystem
{
    public partial class FrmAgregarEditarPrueba : Form
    {
        #region Variables & Instancia

        ServicePruebasLaboratorio _servicioPruebas;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public int id;

        #endregion
        public FrmAgregarEditarPrueba()
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioPruebas = new ServicePruebasLaboratorio(_conexion);
            id = 0;

        }
        #region Eventos
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            AgregarEditar();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Metodos
        private void AgregarEditar()
        {
            PruebasLaboratorios prueba = new PruebasLaboratorios();
            prueba.Id = id;
            prueba.Nombre = txtPrueba.Text.Trim();

            bool resultado = false;

            if (prueba.Nombre == "")
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
                this.Close();
            }
            else
            {
                MessageBox.Show($"Error al {mensajeError} la prueba.");

            }
        }
        #endregion
    }
}
