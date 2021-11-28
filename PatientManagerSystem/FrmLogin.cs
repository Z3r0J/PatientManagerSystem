using BusinessLayer;
using DataLayer.Modelos;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmLogin : Form
    {
        #region Variables & Instancia
        private ServiceUsuarios usuarios;

        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        #endregion
        public FrmLogin()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection(connectionString);
            usuarios = new ServiceUsuarios(conexion);
        }

        #region Eventos
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
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Validar();
            Limpiar();

        }
        #endregion

        #region Eventos
        private void Limpiar()
        {
            txtNombreUsuario.Clear();
            txtContraseña.Clear();
        }
        private void Validar()
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
                    frm.Rol = datos.TipoDeUsuario;
                    frm.Nombre = $"{datos.Nombre} {datos.Apellido}";
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
        #endregion
    }
}
