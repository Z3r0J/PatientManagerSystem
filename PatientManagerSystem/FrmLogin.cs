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
    public partial class FrmLogin : Form
    {
        private ServiceUsuarios usuarios;

        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public FrmLogin()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection(connectionString);
            usuarios = new ServiceUsuarios(conexion);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Maximizar_vlogin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Maximizar_vlogin.Visible = false;
            Restaurar_vlogin.Visible = true;
        }

        private void Restaurar_vlogin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Restaurar_vlogin.Visible = false;
            Maximizar_vlogin.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }
        private void validar()
        {
            try
            {

                if (string.IsNullOrEmpty(txtNombreUsuario.Text))
                {
                    MessageBox.Show("Debe poner su nombre de usuario", "Advertencia");
                }
                else if (string.IsNullOrEmpty(txtContraseña.Text))
                {
                    MessageBox.Show("Debe poner su contraseña", "Advertencia");
                }
                else
                {
                    Usuarios datos = usuarios.Login(txtNombreUsuario.Text, txtContraseña.Text);

                    if (datos != null)
                    {
                        FrmPrincipal frm = new FrmPrincipal();
                        this.Hide();
                        frm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error"+ex);

            }
        }
    }
}
