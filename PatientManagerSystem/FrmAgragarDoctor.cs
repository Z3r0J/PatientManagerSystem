using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PatientManagerSystem
{
    public partial class FrmAgragarDoctor : Form
    {
        public FrmAgragarDoctor()
        {
            InitializeComponent();
            BtnAgregar.Enabled = false;
        }
        public void validar()
        {
           /* if (txt_nombre.Text=="")
            {
                lbl1.Text = "*";

            }
            else
            {
                lbl1.Text = "";
                
            }
            if (txt_apellido.Text=="")
            {
                lbl2.Text = "*";    
            }
            else
            {
                lbl2.Text = "";
            }
            if (txt_correo.Text=="")
            {
                lbl3.Text = "*";
            }
            else
            {
                lbl3.Text = "";
            }
            if (txt_telefono.Text=="")
            {
                lbl4.Text = "*";
            }
            if (txt_nombre.Text == "")
            {
                BtnAgregar.Enabled = true;
            }*/

        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            validar();
        }

    }
}
