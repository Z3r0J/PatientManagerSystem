using BusinessLayer;
using DataLayer;
using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmAgregarDoctor : Form
    {

        public string NombreArchivo;
        public int _id { get; set; }
        public bool Editar { get; set; } = false;
        private ServiceDoctor _serviceDoctor;

        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public FrmAgregarDoctor()
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _serviceDoctor = new ServiceDoctor(_conexion);
        }
        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(txt_nombre.Text))
            {
                MessageBox.Show("Completa el nombre", "Notificacion");
            }
            else if (string.IsNullOrWhiteSpace(txt_apellido.Text))
            {
                MessageBox.Show("Completa el apellido", "Notificacion");
            }
            else if (string.IsNullOrWhiteSpace(txt_correo.Text))
            {
                MessageBox.Show("Completa el correo", "Notificacion");
            }
            else if (txt_telefono.MaskCompleted == false)
            {
                MessageBox.Show("Completa el telefono", "Notificacion");
            }
            else if (txt_cedula.MaskCompleted == false)
            {
                MessageBox.Show("Completa la cedula", "Notificacion");
            }
            else
            {
                if (Editar)
                {
                    if (EditarDoctor())
                    {
                        GuardarFoto();
                        RepositorioID.Instancia.Id = 0;
                        MessageBox.Show("Se ha Editado Correctamente", "Notificacion");
                        Limpiar();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error", "Notificacion");
                    }
                }
                else
                {
                    if (AgregarDoctor())
                    {
                        GuardarFoto();
                        RepositorioID.Instancia.Id = 0;
                        MessageBox.Show("Agregado Correctamente","Notificacion");
                        Limpiar();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error", "Notificacion");
                    }
                }
            }
        }


        public bool AgregarDoctor()
        {
            Medicos medicos = new Medicos()
            {
                Nombre = txt_nombre.Text,
                Apellido = txt_apellido.Text,
                Correo = txt_correo.Text,
                Telefono = txt_telefono.Text,
                Cedula = txt_cedula.Text,
                Foto = NombreArchivo

            };
            bool Add = _serviceDoctor.AgregarDoctor(medicos);

                return Add;
        }

        public bool EditarDoctor()
        {
            Medicos medicos = new Medicos()
            {
                Id = _id,
                Nombre = txt_nombre.Text,
                Apellido = txt_apellido.Text,
                Correo = txt_correo.Text,
                Telefono = txt_telefono.Text,
                Cedula = txt_cedula.Text,
                Foto = NombreArchivo

            };
            bool Edit = _serviceDoctor.EditarDoctor(medicos);

            return Edit;
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Validar();

        }

        private void Limpiar()
        {
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_correo.Clear();
            txt_telefono.Clear();
            txt_cedula.Clear();
            pictureBox1.ImageLocation="";
        }
        private void pictureU_Click(object sender, EventArgs e)
        {
            SeleccionarFoto();
        }

        private void SeleccionarFoto()
        {
            DialogResult result = FotoDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = FotoDialog.FileName;

                NombreArchivo = file;
                pictureBox1.ImageLocation = NombreArchivo;

            }
        }


        private void GuardarFoto()
        {
            if (!string.IsNullOrEmpty(NombreArchivo))
            {
                int id = _id == 0 ? Convert.ToInt32(RepositorioID.Instancia.Id) : _id;


                string directory = @"Images\Doctores\" + id + "\\";

                string[] fileNameSplit = NombreArchivo.Split('\\');
                string filename = fileNameSplit[(fileNameSplit.Length - 1)];

                CreateDirectory(directory);

                string destino = directory + filename;
                try
                {

                    File.Copy(NombreArchivo, destino, true);
                }
                catch { }

                _serviceDoctor.ActualizarFoto(id, destino);
            }


        }
        private void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void FrmAgregarDoctor_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = NombreArchivo;
        }
    }
}
