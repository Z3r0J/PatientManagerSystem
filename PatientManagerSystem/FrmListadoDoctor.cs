using BusinessLayer;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmListadoDoctor : Form
    {
        #region Variables & Instancias
        ServiceDoctor _servicioDoctor;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public char BlackAndLight { get; set; } = 'L';
        private int id;

        public int IdPaciente { get; set; }
        public string NombreApellidoPacientes { get; set; }
        public bool IsOnCitas { get; set; } = false;
        #endregion
        public FrmListadoDoctor(string mensaje, char Tema)
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioDoctor = new ServiceDoctor(_conexion);
            id = 0;
            LblWelcome.Text = mensaje;
            CambiarTema(Tema);
        }


        #region Eventos
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DtgvDoctor.DataSource = _servicioDoctor.BuscarDoctor(textBox1.Text);
        }

        private void btnClaro_Click(object sender, EventArgs e)
        {
            CambiarTema(BlackAndLight);
        }
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
            DtgvDoctor.ClearSelection();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarDoctor frm = new FrmAgregarDoctor();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Deseleccionar();

        }

        private void FrmListadoDoctor_Load(object sender, EventArgs e)
        {
            CargarDoctor();
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
            FrmAgregarCitas frm = new FrmAgregarCitas();
            frm.IdPaciente = IdPaciente;
            frm.IdDoctor = Convert.ToInt32(DtgvDoctor.CurrentRow.Cells[0].Value.ToString());
            frm.NombreApellidoPacientes = NombreApellidoPacientes;
            frm.NombreApellidoDoctor = $"{DtgvDoctor.CurrentRow.Cells[1].Value} {DtgvDoctor.CurrentRow.Cells[2].Value}";
            this.Hide();
            frm.ShowDialog();
            this.Close();
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
                frm._id = Convert.ToInt32(DtgvDoctor.CurrentRow.Cells[0].Value.ToString());
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
                btnAgregar.Image = Properties.Resources.adddoc_white;
                btnEditar.Image = Properties.Resources.editdoc_white;
                btnEliminar.Image = Properties.Resources.deletedoc_white;
                btnDeseleccionar.Image = Properties.Resources.deselect_white;
                this.ForeColor = Color.Black;
                DtgvDoctor.DefaultCellStyle.BackColor = Color.White;
                DtgvDoctor.DefaultCellStyle.ForeColor = Color.Gray;
                DtgvDoctor.BackgroundColor = Color.White;
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
                btnAgregar.Image = Properties.Resources.adddoc_black;
                btnEditar.Image = Properties.Resources.editdoc_black;
                btnEliminar.Image = Properties.Resources.deletedoc_black;
                btnDeseleccionar.Image = Properties.Resources.deselect_black;
                this.ForeColor = Color.White;
                DtgvDoctor.DefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
                DtgvDoctor.DefaultCellStyle.ForeColor = Color.White;
                DtgvDoctor.BackgroundColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));

            }
        }

        #endregion
    }
}
