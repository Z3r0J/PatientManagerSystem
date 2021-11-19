using PatientManagerSystem.CustomComboBoxItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmAgregarEditarUsuarios : Form
    {
        public FrmAgregarEditarUsuarios()
        {
            InitializeComponent();
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
    }
}
