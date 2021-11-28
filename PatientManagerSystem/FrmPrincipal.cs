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
        #region Variables & Instancia
        public int Rol { get; set; } = 1;
        public string Nombre { get; set; }
        public char BlackAndLight { get; set; } = 'B';

        #endregion
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Rols();
            LblName.Text = Nombre;
            tmHora.Start();
            string hour = DateTime.Now.ToString("hh:mm:ss");
            label2.Text = hour;
        }

        private void BtnMantResultadoLab_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmListadosResultados($"Welcome, {Nombre}", BlackAndLight));
        }

        private void BtnMantMedico_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmListadoDoctor($"Welcome, {Nombre}", BlackAndLight));
        }

        private void BtnMantCitas_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmListadoCitas($"Welcome, {Nombre}", BlackAndLight));
        }

        private void BtnMantPruebaLab_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmListadoPrueba($"Welcome, {Nombre}", BlackAndLight));

        }

        private void tmHora_Tick(object sender, EventArgs e)
        {
            string hour = DateTime.Now.ToString("hh:mm:ss");
            label2.Text = hour;
        }

        private void BtnClaroOscuro_Click(object sender, EventArgs e)
        {
            CambiarTema();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Quieres cerrar sesión","Pregunta",MessageBoxButtons.YesNo);

            if (result==DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmListadoUsuarios($"Welcome, {Nombre}",BlackAndLight));

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnWrapper(new FrmListadoPacientes($"Welcome, {Nombre}", BlackAndLight));
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

        #endregion

        #region Metodos

        private void Rols()
        {
            if (Rol==1)
            {

            }
            else
            {
                tableLayoutPanel1.Controls.Add(BtnMantPacientes,0,2);
                tableLayoutPanel1.Controls.Add(BtnMantResultadoLab, 0, 3);
                tableLayoutPanel1.Controls.Add(BtnMantCitas, 0, 4);
                BtnMantUsuario.Visible = false;
                BtnMantMedico.Visible = false;
                BtnMantPruebaLab.Visible = false;
            }
        }

        private void CambiarTema()
        {
            if (BlackAndLight=='B')
            {
                BlackAndLight = 'L';
                BtnClaroOscuro.Text = "Claro ☼";
                this.BackColor = Color.White;
                tableLayoutPanel1.BackColor = Color.White;
                this.ForeColor = Color.Black;
                BtnMantUsuario.ForeColor = Color.Black;
                BtnMantMedico.ForeColor = Color.Black;
                BtnMantPacientes.ForeColor = Color.Black;
                BtnMantPruebaLab.ForeColor = Color.Black;
                BtnMantResultadoLab.ForeColor = Color.Black;
                BtnMantCitas.ForeColor = Color.Black;
                LblCambiarTema.ForeColor = Color.Black;
                BtnClaroOscuro.ForeColor = Color.Black;
                LblName.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                BtnMantUsuario.Image = Properties.Resources.user_white;
                BtnMantMedico.Image = Properties.Resources.doctor_white;
                BtnMantPacientes.Image = Properties.Resources.patient_white;
                BtnMantPruebaLab.Image = Properties.Resources.lab_white;
                BtnMantResultadoLab.Image = Properties.Resources.labresult_white;
                BtnMantCitas.Image = Properties.Resources.appointment_white;
            }
            else
            {
                BlackAndLight = 'B';
                BtnClaroOscuro.Text = "OSCURO 🌙";
                this.BackColor = Color.FromArgb(26, 32, 40);
                tableLayoutPanel1.BackColor = Color.FromArgb(26, 32, 40);
                this.ForeColor = Color.White;
                BtnMantUsuario.ForeColor = Color.White;
                BtnMantMedico.ForeColor = Color.White;
                BtnMantPacientes.ForeColor = Color.White;
                BtnMantPruebaLab.ForeColor = Color.White;
                BtnMantResultadoLab.ForeColor = Color.White;
                BtnMantCitas.ForeColor = Color.White;
                LblCambiarTema.ForeColor = Color.White;
                BtnClaroOscuro.ForeColor = Color.White;
                LblName.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                BtnMantUsuario.Image = Properties.Resources.user_black;
                BtnMantMedico.Image = Properties.Resources.doctor_black;
                BtnMantPacientes.Image = Properties.Resources.patient_black;
                BtnMantPruebaLab.Image = Properties.Resources.lab_black;
                BtnMantResultadoLab.Image = Properties.Resources.labresult_black;
                BtnMantCitas.Image = Properties.Resources.appointment_black;
            }
        }
        #endregion
    }
}
