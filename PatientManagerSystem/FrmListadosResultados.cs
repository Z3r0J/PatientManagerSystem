using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer.Modelos;
using System.Data.SqlClient;
using System.IO;

namespace PatientManagerSystem
{
    public partial class FrmListadosResultados : Form
    {
        ServiceResultadosLab _servicioResultadosLab;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
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
        }


        public void DtgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
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
            if (DtgvResultados.SelectedRows.Count>0)
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
                MessageBox.Show("Selecciona una fila","");
            }
        }
    }
}
