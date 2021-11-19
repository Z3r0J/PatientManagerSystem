using BusinessLayer;
using DataLayer;
using DataLayer.Modelos;
using EmailLayer;
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

        private EnviarCorreo _enviarCorreo;
        public FrmAgregarEditarUsuarios()
        {
            InitializeComponent();

            SqlConnection conexion = new SqlConnection(connectionString);
            usuarios = new ServiceUsuarios(conexion);
            _enviarCorreo = new EnviarCorreo();
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

        private void EnviarCorreo()
        {
            Usuarios users = usuarios.SeleccionCorreo(RepositorioID.Instancia.Id);


            string Body = "<table style = 'width:100%' bgcolor = '#0000'>" +
                   "<tr>" +
                   "<th bgcolor = '#000'>" +
                   $"<img width='200px' height='200px' align ='center' src='{Properties.Resources.LOGO_BLACK}' />" +
                   "</th>" +
                   "</tr>" +
                   "<tr>" +
                   "<td bgcolor='#fff'>" +
                   "<br>" +
                   "<p align=center>" +
                   "<font color='#2d8a13' size=5>" +
                   "<b> Saludos!,</b>" +
                   "</font>" +
                   "<br><br><font color='#299187' size=3><b>" +
                   "Hola "+ users.Nombre + " usted acaba de crear una nueva cuenta.  le generara automaticamente y de manera aleatoria." +
                   "<br><br> Nombre de Usuario: " + users.Usuario + "" +
                   "<br>" +
                   "<br>" +
                   "Desde que inicie en el sistema debe de colocar su usuario y su respectiva contraseña." +
                   "</b>" +
                   "</font>" +
                   "</p>" +
                   "<footer>" +
                   "<font color='#ccc'><i> © " +
                   "2021" +
                " Z3R0 COMPANY BY Denisse Furcal and Jean Carlos Reyes" +
                "</font></i>" +
                   "</footer>" +
                   "<br>" +
                   "</td>" +
                   "</tr>" +
                   "</table>";
            _enviarCorreo.Enviando(users.Correo,"Bienvenid@s a Sistema Gestor de paciente",Body);
        }

        private void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            if (Agregar())
            {
                Clear();
                EnviarCorreo();
                MessageBox.Show("Agregado Correctamente");
            }
        }
    }
}
