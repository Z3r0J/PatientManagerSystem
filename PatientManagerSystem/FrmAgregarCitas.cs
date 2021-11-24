using BusinessLayer;
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
using DataLayer.Modelos;

namespace PatientManagerSystem
{
    public partial class FrmAgregarCitas : Form
    {
        ServiceCitas _servicioCitas;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public int IdPaciente { get; set; }
        public string NombreApellidoPacientes { get; set; }
        public int IdDoctor { get; set; }
        public string NombreApellidoDoctor { get; set; }
        public FrmAgregarCitas()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection(connectionString);
            _servicioCitas = new ServiceCitas(conexion);
        }

        private void FrmAgregarCitas_Load(object sender, EventArgs e)
        {
            DTPHora.Format = DateTimePickerFormat.Time;
            DTPHora.CustomFormat = "HH:mm:ss";
            DTPHora.ShowUpDown = true;
            TxtNombrePaciente.Text = NombreApellidoPacientes;
            TxtNombreDoctor.Text = NombreApellidoDoctor;
        }

        private bool AgregarCitas()
        {
            string Hora = $"{DTPHora.Value.Hour}:{DTPHora.Value.Minute}:{DTPHora.Value.Second}";
            Citas citas = new Citas();
            citas.IdPacientes = IdPaciente;
            citas.IdDoctor = IdDoctor;
            citas.Estado_Citas = 1;
            citas.Fecha_Cita = DTPFecha.Value;
            citas.Hora_Cita = Hora;
            citas.Causa = TxtCausas.Text;


            bool Add = _servicioCitas.AgregarCitas(citas);

                return Add;

        }

        private void Clear()
        {
            IdDoctor = 0;
            IdPaciente = 0;
            TxtCausas.Clear();
            NombreApellidoDoctor = "";
            NombreApellidoPacientes="";
            TxtNombreDoctor.Clear();
            TxtNombrePaciente.Clear();

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (AgregarCitas())
            {
                MessageBox.Show("Se ha agregado correctamente", "Notificacion");
                Clear();
                this.Close();

            }
        }
    }
}
