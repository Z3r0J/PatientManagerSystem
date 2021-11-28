using BusinessLayer;
using DataLayer.Modelos;
using EmailLayer;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmListadoUsuarios : Form
    {

        #region Variables & Instancias

        private ServiceUsuarios usuarios;

        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        private EnviarCorreo _enviarCorreo;
        public char BlackAndLight { get; set; } = 'L';

        #endregion
        public FrmListadoUsuarios(string Nombre, char Tema)
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection(connectionString);
            usuarios = new ServiceUsuarios(conexion);
            _enviarCorreo = new EnviarCorreo();
            LblWelcome.Text = Nombre;
            Deseleccionar();
            CambiarTema(Tema);
        }

        #region Eventos
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarEditarUsuarios frm = new FrmAgregarEditarUsuarios();

            frm.Editar = false;

            this.Hide();
            frm.ShowDialog();
            ListarUsuarios();
            Deseleccionar();
            this.Show();
        }
        private void FrmListadoUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
            DataStyle();
            DtgvUsuarios.ClearSelection();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void DtgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnDeseleccionar.Visible = true;
            }
        }

        private void BtnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
            BtnDeseleccionar.Visible = false;
        }

        private void DtgvUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtgvUsuarios.Rows[0].Selected = false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CambiarTema(BlackAndLight);
        }

        #endregion

        #region Metodos

        private void DataStyle()
        {
            DtgvUsuarios.Columns[0].Width = 100;
            DtgvUsuarios.Columns[1].Width = 160;
            DtgvUsuarios.Columns[2].Width = 220;
            DtgvUsuarios.Columns[3].Width = 290;
            DtgvUsuarios.Columns[4].Width = 300;

        }
        private void ListarUsuarios()
        {
            DtgvUsuarios.DataSource = usuarios.ListadoUsuarios();
        }
        private void Deseleccionar()
        {
            DtgvUsuarios.ClearSelection();
            DtgvUsuarios.CurrentCell = null;
        }

        private void Editar()
        {
            if (DtgvUsuarios.SelectedRows.Count > 0)
            {
                FrmAgregarEditarUsuarios frm = new FrmAgregarEditarUsuarios();

                int a;

                if (DtgvUsuarios.CurrentRow.Cells[6].Value.ToString() == "Administrador")
                {
                    a = 1;
                }
                else
                {
                    a = 2;
                }
                frm.Editar = true;
                frm.Id = Convert.ToInt32(DtgvUsuarios.CurrentRow.Cells[0].Value.ToString());
                frm.TxtNombre.Text = DtgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                frm.TxtApellido.Text = DtgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                frm.TxtUsuario.Text = DtgvUsuarios.CurrentRow.Cells[3].Value.ToString();
                frm.TxtCorreo.Text = DtgvUsuarios.CurrentRow.Cells[4].Value.ToString();
                frm.TxtContraseña.Text = DtgvUsuarios.CurrentRow.Cells[5].Value.ToString();
                frm.TxtConfirmarContraseña.Text = DtgvUsuarios.CurrentRow.Cells[5].Value.ToString();
                frm.CbxTipoUsuario.SelectedIndex = a;
                this.Hide();
                frm.ShowDialog();
                ListarUsuarios();
                Deseleccionar();
                this.Show();
            }

            else
            {
                MessageBox.Show("Seleccione una fila", "Notificacion");
            }
        }

        private void Eliminar()
        {
            if (DtgvUsuarios.SelectedRows.Count > 0)
            {
                Usuarios us = new Usuarios();
                us.Id= Convert.ToInt32(DtgvUsuarios.CurrentRow.Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("¿Estas seguro de eliminar este usuario","Pregunta", MessageBoxButtons.YesNo);
                if (result==DialogResult.Yes)
                {
                    bool Eliminar = usuarios.Eliminar(us);

                    if (Eliminar)
                    {
                        MessageBox.Show("Eliminado correctamente", "Notificacion");
                    }
                    else
                    {
                        MessageBox.Show("Oops, ha ocurrido error", "Notificacion");
                    }

                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila", "Notificacion");
            }
        }

        private void CambiarTema(char Tema)
        {
            if (Tema=='B' || BlackAndLight=='B')
            {
                BlackAndLight = 'L';
                this.BackColor = Color.White;
                button5.Text = "Claro ☼";
                BtnAgregar.ForeColor = Color.Black;
                BtnEditar.ForeColor = Color.Black;
                BtnEliminar.ForeColor = Color.Black;
                BtnAgregar.ForeColor = Color.Black;
                BtnDeseleccionar.ForeColor = Color.Black;
                button5.ForeColor = Color.Black;
                BtnAgregar.Image = Properties.Resources.adduser_white;
                BtnEditar.Image = Properties.Resources.edituser_white;
                BtnEliminar.Image = Properties.Resources.deleteuser_white;
                BtnDeseleccionar.Image = Properties.Resources.deselect_white;
                this.ForeColor = Color.Black;
                DtgvUsuarios.DefaultCellStyle.BackColor = Color.White;
                DtgvUsuarios.DefaultCellStyle.ForeColor = Color.Gray;
                DtgvUsuarios.BackgroundColor = Color.White;
            }
            else
            {
                BlackAndLight = 'B';
                this.BackColor = Color.FromArgb(26, 32, 40);
                button5.Text = "OSCURO 🌙";
                BtnAgregar.ForeColor = Color.White;
                BtnEditar.ForeColor = Color.White;
                BtnEliminar.ForeColor = Color.White;
                BtnAgregar.ForeColor = Color.White;
                BtnDeseleccionar.ForeColor = Color.White;
                button5.ForeColor = Color.White;
                BtnAgregar.Image = Properties.Resources.adduser_black;
                BtnEditar.Image = Properties.Resources.edituser_black;
                BtnEliminar.Image = Properties.Resources.deleteuser_black;
                BtnDeseleccionar.Image = Properties.Resources.deselect_black;
                this.ForeColor = Color.White;
                DtgvUsuarios.DefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
                DtgvUsuarios.DefaultCellStyle.ForeColor = Color.White;
                DtgvUsuarios.BackgroundColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));

            }
        }
        #endregion
    }
}
