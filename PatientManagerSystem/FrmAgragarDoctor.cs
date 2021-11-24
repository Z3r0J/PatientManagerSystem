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
            bool ok = true;

            if (string.IsNullOrEmpty(txt_nombre.Text))
            {
                ok = false;
                lbl1.Text = "*";

            }
            else
            {
                lbl1.Text = "";
                BtnAgregar.Enabled = true;

            }
            if (string.IsNullOrEmpty(txt_apellido.Text))
            {
                ok = false;
                lbl2.Text = "*";
            }
            else
            {
                lbl2.Text = "";
                BtnAgregar.Enabled = true;

            }

            if (string.IsNullOrEmpty(txt_correo.Text))
            {
                ok = false;
                lbl3.Text = "*";
            }
            else
            {
                lbl3.Text = "";
                BtnAgregar.Enabled = true;

            }

            if (string.IsNullOrEmpty(txt_telefono.Text))
            {
                ok = false;
                lbl4.Text = "*";

            }
            else
            {
                lbl4.Text = "";
                BtnAgregar.Enabled = true;
            }

            if (string.IsNullOrEmpty(txt_cedula.Text))
            {
                ok = false;
                BtnAgregar.Enabled = true;
            }
            else
            {
                lbl5.Text = "";
                BtnAgregar.Enabled = true;

            }
            

        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            validar();
        }

    }
}
