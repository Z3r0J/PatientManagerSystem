using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Restaurar_v2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
          restaurar_v2.Visible = false;
            maximizar_v2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
           maximizar_v2.Visible = false;
            restaurar_v2.Visible = true;
        }
    }
}
