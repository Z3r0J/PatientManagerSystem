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
    public partial class FrmListadoPrueba : Form
    {
        ServicePruebasLaboratorio _servicioPrueba;
        ServiceResultadosLab _serviceResultados;
        ServiceCitas _serviceCitas;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private int id;
        public bool IsOnCitas { get; set; } = false;
        public int IdPacientes { get; set; }
        public int IdDoctor { get; set; }
        public int IdCitas { get; set; }
        public FrmListadoPrueba()
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioPrueba = new ServicePruebasLaboratorio(_conexion);

            id = 0;
        }
        FrmAgregarEditarPrueba frm;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarPrueba();
        }
        private void btn_CrearPruebas(object sender, EventArgs e)
        {
            AgregarPruebas_EditarEstadoCitas();
        }

        public void AgregarPruebas_EditarEstadoCitas()
        {
            ResultadosLaboratorios resultados;
            Citas citas = new Citas();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _serviceCitas = new ServiceCitas(_conexion);

            foreach (DataGridViewRow item in dgvPruebas.SelectedRows)
            {
                _serviceResultados = new ServiceResultadosLab(_conexion);
                resultados = new ResultadosLaboratorios();
                resultados.Pacientes.Id = IdPacientes;
                resultados.Citas.Id = IdCitas;
                resultados.PruebasLaboratorios.Id = Convert.ToInt32(dgvPruebas.Rows[item.Index].Cells[0].Value.ToString());
                resultados.Medicos.Id = IdDoctor;
                resultados.Resultados = " ";
                resultados.Estado = 1;

                bool serviceResultados = _serviceResultados.AgregarPruebas(resultados);

                if (serviceResultados)
                {
                    MessageBox.Show($"Se agrego correctamente la prueba de {dgvPruebas.Rows[item.Index].Cells[1].Value}");
                }
            }

            citas.Id = IdCitas;
            citas.Estado_Citas = 2;

            bool serviceC = _serviceCitas.ActualizarEstado(citas);
            if (serviceC)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Oops Error!","Notificacion");
            }

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarPrueba();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarPrueba();
        }
        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void dgvPruebas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsOnCitas)
            {
                if (e.RowIndex>=0)
                {
                        btnAgregar.Visible = true;
                }
            }
            if (e.RowIndex>0)
            {
                id = Convert.ToInt32(dgvPruebas.CurrentRow.Cells[0].Value.ToString());
                btnDeseleccionar.Visible = true;
            }

        }
        private void DtgStyle()
        {
            dgvPruebas.Columns[0].Width = dgvPruebas.Width / 2;
            dgvPruebas.Columns[1].Width = dgvPruebas.Width / 2;
           
        }
        private void CargarPruebas()
        {
            dgvPruebas.DataSource = _servicioPrueba.ObtenerPrueba();
        }

        private void AgregarPrueba()
        {
            Deseleccionar();
            frm = new FrmAgregarEditarPrueba();
            frm.id = 0;
            frm.ShowDialog();
            CargarPruebas();
        }

        private void Deseleccionar()
        {
            dgvPruebas.ClearSelection();
            dgvPruebas.CurrentCell = null;
            btnDeseleccionar.Visible = false;
        }

        private void EditarPrueba()
        {
            if (dgvPruebas.SelectedRows.Count > 0)
            {
                frm = new FrmAgregarEditarPrueba();

               frm.id = Convert.ToInt32(dgvPruebas.CurrentRow.Cells[0].Value.ToString());

                frm.txtPrueba.Text = dgvPruebas.CurrentRow.Cells[1].Value.ToString();
                this.Hide();
                frm.ShowDialog();
                Deseleccionar();
                CargarPruebas();
                this.Show();
                frm.id = 0;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una prueba");
            }
        }

        private void EliminarPrueba()
        {

            if (dgvPruebas.SelectedRows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Esta seguro que desea eliminar la prueba?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    id = Convert.ToInt32(dgvPruebas.CurrentRow.Cells[0].Value.ToString());

                    var result = _servicioPrueba.EliminarPrueba(id);
                    if (result)
                    {
                        MessageBox.Show("La prueba se ha eliminado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Deseleccionar();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar la prueba", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else
            {
                MessageBox.Show("Seleccione una fila", "Notificacion");
            }
            CargarPruebas();

        }

        private void FrmListadoPrueba_Load(object sender, EventArgs e)
        {
            CargarPruebas();
            DtgStyle();
            EstaEnCitas();

        }

        private void EstaEnCitas()
        {
            if (IsOnCitas)
            {
                btnAgregar.Text = "Crear Pruebas";
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnAgregar.Visible = false;

                btnAgregar.Click -= new EventHandler(btnAgregar_Click);
                btnAgregar.Click += new EventHandler(btn_CrearPruebas);
                dgvPruebas.MultiSelect = true;
            }
        }

        private void dgvPruebas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPruebas.Rows[0].Selected = false;
        }
    }
}
