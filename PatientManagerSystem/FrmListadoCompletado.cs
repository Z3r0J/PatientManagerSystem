using BusinessLayer;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmListadoCompletado : Form
    {
        ServiceResultadosLab _serviceResultados;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public int IdPacientes { get; set; }
        public int IdCitas { get; set; }
        public FrmListadoCompletado()
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _serviceResultados = new ServiceResultadosLab(_conexion);
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void dgvPruebas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnDeseleccionar.Visible = true;
            }

        }
        private void CargarPruebas()
        {
            DtgvListadoCompletados.DataSource = _serviceResultados.ListadoResultadoCompletados(IdPacientes, IdCitas);
        }

        private void Deseleccionar()
        {
            DtgvListadoCompletados.ClearSelection();
            DtgvListadoCompletados.CurrentCell = null;
            btnDeseleccionar.Visible = false;
        }


        private void FrmListadoPrueba_Load(object sender, EventArgs e)
        {
            CargarPruebas();

        }

        private void dgvPruebas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtgvListadoCompletados.ClearSelection();
        }

        private void BtnCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
