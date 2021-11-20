using BusinessLayer;
using EmailLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmListadoUsuarios : Form
    {

        private ServiceUsuarios usuarios;

        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        private EnviarCorreo _enviarCorreo;
        public FrmListadoUsuarios()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection(connectionString);
            usuarios = new ServiceUsuarios(conexion);
            _enviarCorreo = new EnviarCorreo();
        }

        private void ListarUsuarios()
        {
            DtgvUsuarios.DataSource = usuarios.ListadoUsuarios();
            DtgvUsuarios.ClearSelection();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void FrmListadoUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();

        }
    }
}
