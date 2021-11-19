using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;

            if (panel2.Width==105)
            {
                this.BackColor = Color.White;
                pictureBox1.Image = Properties.Resources.LOGO_WHITE;
            }
            if (panel2.Width == 207)
            {
                this.BackColor = Color.FromArgb(40, 47, 56);
                pictureBox1.Image = Properties.Resources.LOGO_BLACK;
            }
            if (panel2.Width == 303)
            {
                this.BackColor = Color.White;
                pictureBox1.Image = Properties.Resources.LOGO_WHITE;
            }
            if (panel2.Width == 408)
            {
                this.BackColor = Color.FromArgb(40, 47, 56);
                pictureBox1.Image = Properties.Resources.LOGO_BLACK;
            }

            if (panel2.Width==507)
            {
                this.BackColor = Color.White;
                pictureBox1.Image = Properties.Resources.LOGO_WHITE;
                timer1.Stop();
            }
        }
    }
}
