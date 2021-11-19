using BusinessLayer;
using DataLayer.Modelos;
using PatientManagerSystem.CustomComboBoxItem;
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
    public partial class FrmAgregarEditarUsuarios : Form
    {
        private ServiceUsuarios usuarios;

        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public FrmAgregarEditarUsuarios()
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


        private void LoadCbx()
        {
            ComboBoxItem item = new ComboBoxItem();

            item.Text = "Seleccione una opción";
            item.Value = null;

            ComboBoxItem item1 = new ComboBoxItem() {
                Text = "Administrador",
                Value = 1
            };
            ComboBoxItem item2 = new ComboBoxItem()
            {
                Text = "Medico",
                Value = 2
            };

            CbxTipoUsuario.Items.Add(item);
            CbxTipoUsuario.Items.Add(item1);
            CbxTipoUsuario.Items.Add(item2);
            CbxTipoUsuario.SelectedIndex = 0;

        }

        private void FrmAgregarEditarUsuarios_Load(object sender, EventArgs e)
        {
            LoadCbx();
        }

        private bool Agregar()
        {

            ComboBoxItem item = CbxTipoUsuario.SelectedItem as ComboBoxItem;
            Usuarios user = new Usuarios()
            {
                Nombre = TxtNombre.Text,
            Apellido = TxtApellido.Text,
            Correo = TxtCorreo.Text,
            Usuario = TxtUsuario.Text,
            Contraseña = TxtContraseña.Text,
            TipoDeUsuario = (int)item.Value
            };
            bool add = usuarios.Agregar(user);
                return add;

        }

        private void Clear()
        {
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtCorreo.Clear();
            TxtContraseña.Clear();
            TxtUsuario.Clear();
            TxtConfirmarContraseña.Clear();
            CbxTipoUsuario.SelectedIndex = 0;
        }

        private void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            if (Agregar())
            {
                Clear();
                MessageBox.Show("Agregado Correctamente");
            }
        }
    }
}
