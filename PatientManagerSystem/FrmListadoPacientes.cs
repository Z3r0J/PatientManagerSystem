using BusinessLayer;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmListadoPacientes : Form
    {
        ServicePacientes _servicioPacientes;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private int id;
        public bool IsOnCitas { get; set; }
        public char BlackAndLight { get; set; } = 'L';
        public FrmListadoPacientes(string mensaje,char Tema)
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioPacientes = new ServicePacientes(_conexion);
            id = 0;
            LblWelcome.Text = mensaje;
            CambiarTema(Tema);
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
            dgvPacientes.ClearSelection();
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
            EstaEnCitas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count > 0)
            {
                FrmListadoDoctor frm = new FrmListadoDoctor("",'B');
                frm.IdPaciente = Convert.ToInt32(dgvPacientes.CurrentRow.Cells[0].Value.ToString());
                frm.NombreApellidoPacientes = $"{dgvPacientes.CurrentRow.Cells[1].Value.ToString()} {dgvPacientes.CurrentRow.Cells[2].Value.ToString()}";
                frm.IsOnCitas = true;
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
        }
        public void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (IsOnCitas)
                {
                    btnAgregar.Visible = true;
                }
                btnDeseleccionar.Visible = true;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvPacientes.DataSource = _servicioPacientes.BuscarPacientes(textBox1.Text);
        }

        private void btnClaro_Click(object sender, EventArgs e)
        {
            CambiarTema(BlackAndLight);
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
                btnAgregar.Click -= new EventHandler(btnAgregar_Click);
                btnAgregar.Click += new EventHandler(BtnSiguiente_Click);
                btnAgregar.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void CambiarTema(char Tema)
        {
            if (Tema == 'B' || BlackAndLight == 'B')
            {
                BlackAndLight = 'L';
                this.BackColor = Color.White;
                tableLayoutPanel1.BackColor = Color.White;
                btnClaro.Text = "Claro ☼";
                btnAgregar.ForeColor = Color.Black;
                btnEditar.ForeColor = Color.Black;
                btnEliminar.ForeColor = Color.Black;
                btnAgregar.ForeColor = Color.Black;
                btnDeseleccionar.ForeColor = Color.Black;
                btnClaro.ForeColor = Color.Black;
                btnAgregar.Image = Properties.Resources.addpat_white;
                btnEditar.Image = Properties.Resources.editpat_white;
                btnEliminar.Image = Properties.Resources.deletepat_white;
                btnDeseleccionar.Image = Properties.Resources.deselect_white;
                this.ForeColor = Color.Black;
                dgvPacientes.DefaultCellStyle.BackColor = Color.White;
                dgvPacientes.DefaultCellStyle.ForeColor = Color.Gray;
                dgvPacientes.BackgroundColor = Color.White;
            }
            else
            {
                BlackAndLight = 'B';
                this.BackColor = Color.FromArgb(26, 32, 40);
                tableLayoutPanel1.BackColor = Color.FromArgb(26, 32, 40);
                btnClaro.Text = "OSCURO 🌙";
                btnAgregar.ForeColor = Color.White;
                btnEditar.ForeColor = Color.White;
                btnEliminar.ForeColor = Color.White;
                btnAgregar.ForeColor = Color.White;
                btnDeseleccionar.ForeColor = Color.White;
                btnClaro.ForeColor = Color.White;
                btnAgregar.Image = Properties.Resources.addpat_black;
                btnEditar.Image = Properties.Resources.editpat_black;
                btnEliminar.Image = Properties.Resources.deletepat_black;
                btnDeseleccionar.Image = Properties.Resources.deselect_black;
                this.ForeColor = Color.White;
                dgvPacientes.DefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
                dgvPacientes.DefaultCellStyle.ForeColor = Color.White;
                dgvPacientes.BackgroundColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));

            }
        }

        #endregion
    }
}
