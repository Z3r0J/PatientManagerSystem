using BusinessLayer;
using DataLayer.Modelos;
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
    public partial class FrmPruebaLogin : Form
    {
       private ServiceUsuarios usuarios;

        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public FrmPruebaLogin()
        {
            InitializeComponent();

            SqlConnection conexion = new SqlConnection(connectionString);
            usuarios = new ServiceUsuarios(conexion);
        }
  
       
        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios datos = usuarios.Login(textBox1.Text, textBox2.Text);
            if (datos!=null)
            {
                MessageBox.Show($"Bienvenid@s {datos.Nombre}");
            }
        }
    }
}
