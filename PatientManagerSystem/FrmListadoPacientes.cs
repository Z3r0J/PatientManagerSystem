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
        public FrmListadoPacientes()
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioPacientes = new ServicePacientes(_conexion);
            paciente = new frmAgregarEditarPacientes();
            id = 0;
        }

        public void CargarPacientes()
        {
           
            dgvPacientes.DataSource = _servicioPacientes.ObtenerPacientes(); 
        }

        frmAgregarEditarPacientes paciente;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
            paciente.Show();
            
        }

        private void FrmListadoPacientes_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            paciente.Show();
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDeseleccionar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;

            int _id = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells["Id"].Value.ToString()); ;

            paciente._paciente.Nombre = dgvPacientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            paciente._id = _id;
            paciente._paciente.Id = _id;
            id = _id;
            paciente._paciente.Apellido = dgvPacientes.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
            paciente._paciente.Cedula = dgvPacientes.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
            paciente._paciente.Telefono = dgvPacientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
            paciente._paciente.Direccion = dgvPacientes.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
            paciente._paciente.FechaNacimiento = Convert.ToDateTime(dgvPacientes.Rows[e.RowIndex].Cells["Fecha Nacimiento"].Value.ToString());
            paciente._paciente.Fumador = Convert.ToBoolean(dgvPacientes.Rows[e.RowIndex].Cells["Fumador"].Value.ToString());
            paciente._paciente.Alergias = dgvPacientes.Rows[e.RowIndex].Cells["Alergias"].Value.ToString();
            paciente._paciente.Id = _id;
            paciente._filename = dgvPacientes.Rows[e.RowIndex].Cells["Foto"].Value.ToString();
        }

        public void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Deseleccionar()
        {
            dgvPacientes.ClearSelection();
            paciente._id = 0;
            btnDeseleccionar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Esta seguro que desea eliminar el paciente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                var result = _servicioPacientes.EliminarPaciente(id);
                if (result)
                {
                    MessageBox.Show("El paciente se ha eliminado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar el paciente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            CargarPacientes();
            Deseleccionar();
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }
    }
}
