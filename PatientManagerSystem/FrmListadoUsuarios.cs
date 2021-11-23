using BusinessLayer;
using DataLayer.Modelos;
using EmailLayer;
using System;
using System.Configuration;
using System.Data.SqlClient;
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
            Deseleccionar();
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

        #endregion

        #region Metodos
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
                MessageBox.Show("Seleccione una fila", "Notificacion");
            }
        }
        #endregion
    }
}
