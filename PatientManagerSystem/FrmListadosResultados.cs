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
        #region Variables & Instancia

        ServiceResultadosLab _servicioResultadosLab;
        ServiceCitas _serviceCitas;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public bool IsOnCitas { get; set; } = false;
        public int IdCitas { get; set; }
        public int IdPacientes { get; set; }
        public char BlackAndLight { get; set; } = 'L';

        #endregion

        public FrmListadosResultados(string mensaje, char Tema)
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioResultadosLab = new ServiceResultadosLab(_conexion);
            CambiarTema(Tema);
            LblWelcome.Text = mensaje;
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
        private void btnClaro_Click(object sender, EventArgs e)
        {
            CambiarTema(BlackAndLight);
        }

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

        #endregion

        #region Metodos
        private void DtgStyle()
        {
            DtgvResultados.Columns[0].Width = 70;
            DtgvResultados.Columns[1].Width = 210;
            DtgvResultados.Columns[2].Width = 210;
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
        private void CambiarTema(char Tema)
        {
            if (Tema == 'B' || BlackAndLight == 'B')
            {
                BlackAndLight = 'L';
                this.BackColor = Color.White;
                tableLayoutPanel1.BackColor = Color.White;
                btnClaro.Text = "Claro ☼";
                BtnOculto.ForeColor = Color.Black;
                BtnConsultar.ForeColor = Color.Black;
                btnDeseleccionar.ForeColor = Color.Black;
                btnClaro.ForeColor = Color.Black;
                BtnConsultar.Image = Properties.Resources.result_white;
                btnDeseleccionar.Image = Properties.Resources.deselect_white;
                this.ForeColor = Color.Black;
                LblBuscar.ForeColor = Color.Black;
                DtgvResultados.DefaultCellStyle.BackColor = Color.White;
                DtgvResultados.DefaultCellStyle.ForeColor = Color.Gray;
                DtgvResultados.BackgroundColor = Color.White;
            }
            else
            {
                BlackAndLight = 'B';
                this.BackColor = Color.FromArgb(26, 32, 40);
                tableLayoutPanel1.BackColor = Color.FromArgb(26, 32, 40);
                btnClaro.Text = "OSCURO 🌙";
                BtnOculto.ForeColor = Color.White;
                BtnConsultar.ForeColor = Color.White;
                btnDeseleccionar.ForeColor = Color.White;
                LblBuscar.ForeColor = Color.White;
                btnClaro.ForeColor = Color.White;
                BtnConsultar.Image = Properties.Resources.result_black;
                btnDeseleccionar.Image = Properties.Resources.deselect_black;
                this.ForeColor = Color.White;
                DtgvResultados.DefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
                DtgvResultados.DefaultCellStyle.ForeColor = Color.White;
                DtgvResultados.BackgroundColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));

            }
        }
        private void EstaEnCitas()
        {
            if (IsOnCitas)
            {
                BtnConsultar.Text = "Completar Citas";
                BtnConsultar.Image = null;
                BtnConsultar.Click -= new EventHandler(BtnConsultar_Click);
                BtnConsultar.Click += new EventHandler(BtnCompletar_Click);
                BtnConsultar.Visible = true;
                DtgvResultados.DataSource = _servicioResultadosLab.ListadoResultadosPacientes(IdPacientes, IdCitas);
                BtnOculto.Visible = true;
                BtnOculto.Text = "Cerrar Resultados";
                BtnOculto.Click += new EventHandler(BtnOculto_Click);
                label2.Visible = true;
                label2.Text = "Nombre de la prueba";
                label2.Location = new Point(3, 38);
                label7.Visible = false;
                panel8.Visible = false;
                panel10.Visible = false;
                tableLayoutPanel1.Controls.Add(panel9, 3, 1);
                label6.Text = "Estado de la prueba";
                label6.Location = new Point(3, 38);
            }
        }
        #endregion
    }
}
