using BusinessLayer;
using DataLayer.Modelos;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class frmAgregarEditarPacientes : Form
    {
        #region Variables & Instancias
        ServicePacientes _servicioPacientes;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public string _filename;
        public int _id;
        public Pacientes _paciente;

        #endregion
        public frmAgregarEditarPacientes()
        {
            InitializeComponent();

            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioPacientes = new ServicePacientes(_conexion);

            _id = 0;
            _filename = "";
            _paciente = new Pacientes();
        }

        #region Eventos
        private void frmAgregarEditarPacientes_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {

                TxtNombre.Text = _paciente.Nombre;
                TxtApellido.Text = _paciente.Apellido;
                txtCedula.Text = _paciente.Cedula;
                txtTelefono.Text = _paciente.Telefono;
                txtDireccion.Text = _paciente.Direccion;
                chkFumador.Checked = _paciente.Fumador;
                txtAlergias.Text = _paciente.Alergias;
                PbxFoto.ImageLocation = _filename;

            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                AgregarPaciente();
                this.Close();
            }
            else
            {
                EditarPaciente();
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddPhoto();
        }

        #endregion

        #region Metodos
        private void AgregarPaciente()
        {

            string nombre = TxtNombre.Text.Trim();
            string apellido = TxtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string alergias = txtAlergias.Text.Trim();
            string foto = _filename;

            if (nombre == "" || apellido == "" || telefono == "" || direccion == "" || alergias == "" || foto == "" || cedula == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var paciente = OPaciente();
            var result = _servicioPacientes.AgregarPaciente(paciente);

            if (result)
            {
                SavePhoto();
                MessageBox.Show("Se agrego el paciente con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se ha podido agregar el paciente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        private void EditarPaciente()
        {

            string nombre = TxtNombre.Text.Trim();
            string apellido = TxtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string alergias = txtAlergias.Text.Trim();
            string foto = _filename;

            if (nombre == "" || apellido == "" || telefono == "" || direccion == "" || alergias == "" || foto == "" || cedula == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var paciente = OPaciente();
            var result = _servicioPacientes.EditarPaciente(paciente);
            if (result)
            {
                SavePhoto();
                MessageBox.Show("Se edito el paciente con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se ha podido editar el paciente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private Pacientes OPaciente()
        {

            Pacientes paciente = new Pacientes();
            paciente.Nombre = TxtNombre.Text.Trim();
            paciente.Apellido = TxtApellido.Text.Trim();
            paciente.Telefono = txtTelefono.Text.Trim();
            paciente.Direccion = txtDireccion.Text.Trim();
            paciente.Cedula = txtCedula.Text.Trim();
            paciente.FechaNacimiento = dtFecha_Nacimiento.Value;
            paciente.Fumador = chkFumador.Checked ? true : false;
            paciente.Alergias = txtAlergias.Text.Trim();
            paciente.Foto = _filename;
            paciente.Id = _id;


            return paciente;
        }
        private void AddPhoto()
        {
            DialogResult result = FotoDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = FotoDialog.FileName;

                _filename = file;
                PbxFoto.ImageLocation = _filename;

            }
        }

        private void SavePhoto()
        {
            if (!string.IsNullOrEmpty(_filename))
            {
                int id = _id == 0 ? _servicioPacientes.GetLastId() : _id;


                string directory = @"Images\Pacientes\" + id + "\\";

                string[] fileNameSplit = _filename.Split('\\');
                string filename = fileNameSplit[(fileNameSplit.Length - 1)];

                CreateDirectory(directory);

                string destination = directory + filename;
                try
                {

                    File.Copy(_filename, destination, true);
                }
                catch { }

                _servicioPacientes.SavePhoto(id, destination);
            }


        }
        private void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private void LimpiarCampos()
        {
            TxtNombre.Clear();
            TxtApellido.Clear();
            txtCedula.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtAlergias.Clear();
            PbxFoto.ImageLocation = "";
            dtFecha_Nacimiento.Value = DateTime.Now;
            chkFumador.Checked = false;
            _id = 0;
        }
        #endregion

    }
}
