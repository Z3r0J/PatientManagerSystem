using BusinessLayer;
using DataLayer;
using DataLayer.Modelos;
using EmailLayer;
using PatientManagerSystem.CustomComboBoxItem;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmAgregarEditarUsuarios : Form
    {
        public bool Editar { get; set; }

        public int Id { get; set; }
        private ServiceUsuarios usuarios;

        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        private EnviarCorreo _enviarCorreo;
        public FrmAgregarEditarUsuarios()
        {
            InitializeComponent();

            SqlConnection conexion = new SqlConnection(connectionString);
            usuarios = new ServiceUsuarios(conexion);
            _enviarCorreo = new EnviarCorreo();
            LoadCbx();
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

            ComboBoxItem item1 = new ComboBoxItem()
            {
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

        private bool EditarUsuarios()
        {

            ComboBoxItem item = CbxTipoUsuario.SelectedItem as ComboBoxItem;


            Usuarios user = new Usuarios()
            {
                Id = Id,
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                Correo = TxtCorreo.Text,
                Usuario = TxtUsuario.Text,
                Contraseña = TxtContraseña.Text,
                TipoDeUsuario = (int)item.Value
            };
            bool add = usuarios.Actualizar(user);
            return add;

        }

        private void Validar()
        {
            bool Existe = usuarios.Existe(TxtUsuario.Text);
            ComboBoxItem item = CbxTipoUsuario.SelectedItem as ComboBoxItem;
            if (item.Value == null)
            {
                MessageBox.Show("Elige un tipo de usuario", "Notificación");
            }
            else if (string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MessageBox.Show("Inserta un nombre", "Notificación");
            }
            else if (string.IsNullOrWhiteSpace(TxtApellido.Text))
            {
                MessageBox.Show("Inserta un Apellido", "Notificación");
            }
            else if (string.IsNullOrWhiteSpace(TxtCorreo.Text))
            {
                MessageBox.Show("Inserta un Correo", "Notificación");
            }
            else if (string.IsNullOrWhiteSpace(TxtUsuario.Text))
            {
                MessageBox.Show("Inserta un Usuario", "Notificación");
            }
            else if (string.IsNullOrWhiteSpace(TxtContraseña.Text))
            {
                MessageBox.Show("Inserta una contraseña", "Notificación");

            }
            else if (TxtConfirmarContraseña.Text != TxtContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Notificación");
            }
            else if (Existe)
            {
                MessageBox.Show("Este usuario existe", "Notificación");
            }
            else
            {
                if (Agregar())
                {
                    Clear();
                    EnviarCorreo();
                    MessageBox.Show("Agregado Correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Oops, ha ocurrido un error", "Notificación");
                }
            }
        }


        private void Editando()
        {
            ComboBoxItem item = CbxTipoUsuario.SelectedItem as ComboBoxItem;
            if (item.Value == null)
            {
                MessageBox.Show("Elige un tipo de usuario", "Notificación");
            }
            else if (string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MessageBox.Show("Inserta un nombre", "Notificación");
            }
            else if (string.IsNullOrWhiteSpace(TxtApellido.Text))
            {
                MessageBox.Show("Inserta un Apellido", "Notificación");
            }
            else if (string.IsNullOrWhiteSpace(TxtCorreo.Text))
            {
                MessageBox.Show("Inserta un Correo", "Notificación");
            }
            else if (string.IsNullOrWhiteSpace(TxtUsuario.Text))
            {
                MessageBox.Show("Inserta un Usuario", "Notificación");
            }
            else if (string.IsNullOrWhiteSpace(TxtContraseña.Text))
            {
                MessageBox.Show("Inserta una contraseña", "Notificación");

            }
            else if (TxtConfirmarContraseña.Text != TxtContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Notificación");
            }
            else
            {
                if (EditarUsuarios())
                {
                    MessageBox.Show("Editado Correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Oops, ha ocurrido un error", "Notificación");
                }
            }

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


            string Body = "<table style = 'width:100%' bgcolor = '#282F38'>" +
                   "<tr>" +
                   "<th bgcolor = '#282F38'>" +
                   "<img width='200px' height='200px' align ='center' src='https://i.imgur.com/ntNdCPg.png' />" +
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
                   "Atención " + users.Nombre + ", se acaba de crear una nueva cuenta en el Sistema Gestor de Pacientes. Este correo se genero automaticamente y es un mensaje de seguridad." +
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
            _enviarCorreo.Enviando(users.Correo, $"Bienvenid@s a Sistema Gestor de paciente {users.Nombre}", Body);
        }

        private void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            if (Editar)
            {
                Editando();
            }
            else
            {
                Validar();
            }
        }
    }
}
