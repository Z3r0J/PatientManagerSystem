using BusinessLayer;
using DataLayer.Modelos;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmListadosResultados : Form
    {
        ServiceResultadosLab _servicioResultadosLab;
        ServiceCitas _serviceCitas;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public bool IsOnCitas { get; set; } = false;
        public int IdCitas { get; set; }
        public int IdPacientes { get; set; }
        public FrmListadosResultados()
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioResultadosLab = new ServiceResultadosLab(_conexion);
        }

        #region Eventos

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void DtgvResultados_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtgvResultados.ClearSelection();
        }

        private void FrmListadoPacientes_Load(object sender, EventArgs e)
        {
            CargarPruebasLab();
            DtgStyle();
            Deseleccionar();
            EstaEnCitas();
        }


        public void DtgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnConsultar.Visible = true;
                btnDeseleccionar.Visible = true;
            }
        }

        #endregion

        #region Metodos

        private void DtgStyle()
        {

        }

        private void CargarPruebasLab()
        {
            DtgvResultados.DataSource = _servicioResultadosLab.ListarResultados();
        }

        private void Deseleccionar()
        {
            DtgvResultados.ClearSelection();
            DtgvResultados.CurrentCell = null;
            btnDeseleccionar.Visible = false;
            BtnConsultar.Visible = false;
        }

        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DtgvResultados.DataSource = _servicioResultadosLab.BuscarResultados(TxtBuscar.Text);
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (DtgvResultados.SelectedRows.Count > 0)
            {
                FrmAgregarResultados frm = new FrmAgregarResultados();

                frm.Id = Convert.ToInt32(DtgvResultados.CurrentRow.Cells[0].Value.ToString());

                this.Hide();
                frm.ShowDialog();
                Deseleccionar();
                CargarPruebasLab();
                BtnConsultar.Visible = false;
                this.Show();
            }
            else
            {
                MessageBox.Show("Selecciona una fila", "");
            }
        }

        private void BtnCompletar_Click(object sender, EventArgs e)
        {
            SqlConnection _conexion = new SqlConnection(connectionString);
            _serviceCitas = new ServiceCitas(_conexion);

            Citas citas = new Citas()
            {
                Id = IdCitas,
                Estado_Citas = 3
            };


            bool Complete = _serviceCitas.ActualizarEstado(citas);
            if (Complete)
            {
                MessageBox.Show("Se completo la cita correctamente");
                this.Close();
            }
        }
        private void BtnOculto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EstaEnCitas()
        {
            if (IsOnCitas)
            {
                BtnConsultar.Text = "Completar Citas";
                BtnConsultar.Click -= new EventHandler(BtnConsultar_Click);
                BtnConsultar.Click += new EventHandler(BtnCompletar_Click);
                BtnConsultar.Visible = true;
                DtgvResultados.DataSource = _servicioResultadosLab.ListadoResultadosPacientes(IdPacientes, IdCitas);
                BtnOculto.Visible = true;
                BtnOculto.Text = "Cerrar Resultados";
                BtnOculto.Click += new EventHandler(BtnOculto_Click);
                label2.Visible = false;
                label3.Text = "Nombre de la prueba";
                label3.Location = new Point(3, 38);
                label4.Visible = false;
                panel8.Visible = false;
                panel10.Visible = false;
                tableLayoutPanel1.Controls.Add(panel9, 3, 1);
                label6.Text = "Estado de la prueba";
                label6.Location = new Point(2,15);
            }
        }
    }
}
