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
        public int Rol { get; set; }
        public string Nombre { get; set; }
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
            this.Close();
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


        private Form FormActivado = null;
        private void AbrirFormularioEnWrapper(Form FormHijo)
        {
            if (FormActivado != null)
                FormActivado.Close();
            FormActivado = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.Dock = DockStyle.Fill;
            Wrapper.Controls.Add(FormHijo);
            Wrapper.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmListadoUsuarios());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmListadoPacientes());
        }


        private void Rols()
        {
            if (Rol==1)
            {

            }
            else
            {
                BtnMantUsuario.Visible = false;
                BtnMantMedico.Visible = false;
                BtnMantPruebaLab.Visible = false;
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Rols();
            LblName.Text = Nombre;
        }
    }
}
