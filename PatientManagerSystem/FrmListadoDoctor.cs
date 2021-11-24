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
    public partial class FrmListadoDoctor : Form
    {
        ServiceDoctor _servicioDoctor;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private int id;

        public bool IsOnCitas { get; set; } = false;
        public FrmListadoDoctor()
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioDoctor = new ServiceDoctor(_conexion);
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

        private void DtgvDoctor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtgvDoctor.Rows[0].Selected = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarDoctor frm = new FrmAgregarDoctor();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Deseleccionar();
            
        }

        private void FrmListadoPacientes_Load(object sender, EventArgs e)
        {
            CargarDoctor();
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
            DtgvDoctor.Columns[0].Width = 70;
            DtgvDoctor.Columns[1].Width = 160;
            DtgvDoctor.Columns[2].Width = 220;
            DtgvDoctor.Columns[3].Width = 270;
        }
        private void CargarDoctor()
        {

            DtgvDoctor.DataSource = _servicioDoctor.ListarDoctor();
        }
        private void Editar()
        {
            if (DtgvDoctor.SelectedRows.Count > 0)
            {
                FrmAgregarDoctor frm = new FrmAgregarDoctor();
                frm._id= Convert.ToInt32(DtgvDoctor.CurrentRow.Cells[0].Value.ToString());
                frm.txt_nombre.Text = DtgvDoctor.CurrentRow.Cells[1].Value.ToString();
                frm.txt_apellido.Text = DtgvDoctor.CurrentRow.Cells[2].Value.ToString();
                frm.txt_correo.Text = DtgvDoctor.CurrentRow.Cells[3].Value.ToString();
                frm.txt_telefono.Text = DtgvDoctor.CurrentRow.Cells[4].Value.ToString();
                frm.txt_cedula.Text = DtgvDoctor.CurrentRow.Cells[5].Value.ToString();
                frm.NombreArchivo = DtgvDoctor.CurrentRow.Cells[6].Value.ToString();
                frm.Editar = true;
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Selecciona un Doctor");
            }
        }

        private void Eliminar()
        {
            if (DtgvDoctor.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(DtgvDoctor.CurrentRow.Cells[0].Value.ToString());
                if (DialogResult.Yes == MessageBox.Show("Esta seguro que desea eliminar el paciente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    bool result = _servicioDoctor.EliminarDoctor(id);
                    if (result)
                    {
                        MessageBox.Show("El Doctor se ha eliminado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDoctor();
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
            DtgvDoctor.ClearSelection();
            DtgvDoctor.CurrentCell = null;
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


    }
}
