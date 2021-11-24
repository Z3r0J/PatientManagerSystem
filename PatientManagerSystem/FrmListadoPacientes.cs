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
    public partial class FrmListadoPacientes : Form
    {
        ServicePacientes _servicioPacientes;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private int id;

        public bool IsOnCitas { get; set; }
        public FrmListadoPacientes()
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioPacientes = new ServicePacientes(_conexion);
            id = 0;
        }
        frmAgregarEditarPacientes paciente;


        #region Eventos
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void dgvPacientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPacientes.Rows[0].Selected = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
            paciente = new frmAgregarEditarPacientes();
            paciente._id = 0;
            paciente.Show();
            
        }

        private void FrmListadoPacientes_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            DtgStyle();
            Deseleccionar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            Editar();
        }
        public void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                btnDeseleccionar.Visible = true;
            }
        }

        #endregion

        #region Metodos

        private void DtgStyle()
        {
            dgvPacientes.Columns[0].Width = 70;
            dgvPacientes.Columns[1].Width = 160;
            dgvPacientes.Columns[2].Width = 220;
            dgvPacientes.Columns[3].Width = 270;
        }
        private void CargarPacientes()
        {

            dgvPacientes.DataSource = _servicioPacientes.ObtenerPacientes();
        }
        private void Editar()
        {
            if (dgvPacientes.SelectedRows.Count > 0)
            {
                paciente = new frmAgregarEditarPacientes();

                int _id = Convert.ToInt32(dgvPacientes.CurrentRow.Cells[0].Value.ToString());

                paciente._paciente.Nombre = dgvPacientes.CurrentRow.Cells[1].Value.ToString();
                paciente._id = _id;
                paciente._paciente.Id = _id;
                id = _id;
                paciente._paciente.Apellido = dgvPacientes.CurrentRow.Cells[2].Value.ToString();
                paciente._paciente.Telefono = dgvPacientes.CurrentRow.Cells[3].Value.ToString();
                paciente._paciente.Direccion = dgvPacientes.CurrentRow.Cells[4].Value.ToString();
                paciente._paciente.Cedula = dgvPacientes.CurrentRow.Cells[5].Value.ToString();
                paciente._paciente.FechaNacimiento = Convert.ToDateTime(dgvPacientes.CurrentRow.Cells[6].Value.ToString());
                paciente._paciente.Fumador = Convert.ToBoolean(dgvPacientes.CurrentRow.Cells[7].Value.ToString());
                paciente._paciente.Alergias = dgvPacientes.CurrentRow.Cells[8].Value.ToString();
                paciente._paciente.Id = _id;
                paciente._filename = dgvPacientes.CurrentRow.Cells[9].Value.ToString();
                this.Hide();
                paciente.ShowDialog();
                Deseleccionar();
                this.Show();
                paciente._id = 0;
            }
            else
            {
                MessageBox.Show("Selecciona un paciente");
            }
        }

        private void Eliminar()
        {
            if (dgvPacientes.SelectedRows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Esta seguro que desea eliminar el paciente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    var result = _servicioPacientes.EliminarPaciente(id);
                    if (result)
                    {
                        MessageBox.Show("El paciente se ha eliminado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPacientes();
                        Deseleccionar();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el paciente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            dgvPacientes.ClearSelection();
            dgvPacientes.CurrentCell = null;
            btnDeseleccionar.Visible = false;
        }

        private void EstaEnCitas()
        {
            if (IsOnCitas)
            {
                btnAgregar.Text = "Siguiente";
                btnAgregar.Click += new EventHandler(BtnSiguiente_Click);
            }
        }

        #endregion

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
