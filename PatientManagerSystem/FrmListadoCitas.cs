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
    public partial class FrmListadoCitas : Form
    {
        ServiceCitas _servicioCitas;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private int id;
        public FrmListadoCitas()
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioCitas = new ServiceCitas(_conexion);
            id = 0;
        }


        #region Eventos
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void DtgvCitas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtgvCitas.Rows[0].Selected = false;
        }

        private void FrmListadoPacientes_Load(object sender, EventArgs e)
        {
            CargarMedicos();
            DtgStyle();
            Deseleccionar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            FrmListadoPrueba frm = new FrmListadoPrueba();
            frm.IdPacientes = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[7].Value.ToString());
            frm.IdDoctor = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[8].Value.ToString());
            frm.IdCitas = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[0].Value.ToString());
            frm.IsOnCitas = true;
            this.Hide();
            frm.ShowDialog();
            CargarMedicos();
            this.Show();
            
        }
        private void BtnConsultarResultados_Click(object sender, EventArgs e)
        {
            FrmListadosResultados frm = new FrmListadosResultados();
            frm.IdPacientes = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[7].Value.ToString());
            frm.IdCitas = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[0].Value.ToString());
            frm.IsOnCitas = true;
            this.Hide();
            frm.ShowDialog();
            CargarMedicos();
            this.Show();

        }

        private void BtnVerResultados_Click(object sender, EventArgs e)
        {
            FrmListadoCompletado frm = new FrmListadoCompletado();
            frm.IdPacientes = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[7].Value.ToString());
            frm.IdCitas = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[0].Value.ToString());
            this.Hide();
            frm.ShowDialog();
            CargarMedicos();
            this.Show();

        }
        public void DgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString())==1)
                {
                    BtnConsultar.Text = "Consultar";
                    BtnConsultar.Click -= new EventHandler(BtnVerResultados_Click);
                    BtnConsultar.Click -= new EventHandler(BtnConsultarResultados_Click);
                    BtnConsultar.Click += new EventHandler(BtnConsultar_Click);
                }
                else if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 2)
                {
                    BtnConsultar.Text = "Consultar Resultados";
                    BtnConsultar.Click -= new EventHandler(BtnVerResultados_Click);
                    BtnConsultar.Click -= new EventHandler(BtnConsultar_Click);
                    BtnConsultar.Click += new EventHandler(BtnConsultarResultados_Click);

                }
                else if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 3)
                {
                    BtnConsultar.Text = "Ver Resultados";
                    BtnConsultar.Click -= new EventHandler(BtnConsultarResultados_Click);
                    BtnConsultar.Click -= new EventHandler(BtnConsultar_Click);
                    BtnConsultar.Click += new EventHandler(BtnVerResultados_Click);

                }
                btnDeseleccionar.Visible = true;
            }
        }

        #endregion

        #region Metodos

        private void DtgStyle()
        {
            DtgvCitas.Columns[0].Width = 70;
            DtgvCitas.Columns[7].Visible = false;
            DtgvCitas.Columns[8].Visible = false;
            DtgvCitas.Columns[9].Visible = false;
        }
        private void CargarMedicos()
        {

            DtgvCitas.DataSource = _servicioCitas.ListarCitas();
        }
        private void Editar()
        {
            if (DtgvCitas.SelectedRows.Count > 0)
            {
               
            }
            else
            {
                MessageBox.Show("Selecciona un Doctor");
            }
        }

        private void Eliminar()
        {
            if (DtgvCitas.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[0].Value.ToString());
                if (DialogResult.Yes == MessageBox.Show("Esta seguro que desea eliminar el paciente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    bool result=false;
                    if (result)
                    {
                        MessageBox.Show("El Doctor se ha eliminado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarMedicos();
                        Deseleccionar();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el Doctor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else
            {
                MessageBox.Show("Seleccione una fila", "Notificacion");
            }
        }

        private void Deseleccionar()
        {
            DtgvCitas.ClearSelection();
            DtgvCitas.CurrentCell = null;
            btnDeseleccionar.Visible = false;
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmListadoPacientes frm = new FrmListadoPacientes();
            frm.IsOnCitas = true;
            this.Hide();
            frm.ShowDialog();
            CargarMedicos();
            this.Show();
        }
    }
}
