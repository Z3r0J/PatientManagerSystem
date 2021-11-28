using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer.Modelos;
using System.Data.SqlClient;
using System.IO;

namespace PatientManagerSystem
{
    public partial class FrmListadoCitas : Form
    {
        #region Variables & Instancias

        ServiceCitas _servicioCitas;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private int id;
        public char BlackAndLight { get; set; } = 'L';

        #endregion
        public FrmListadoCitas(string mensaje,char Tema)
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _servicioCitas = new ServiceCitas(_conexion);
            id = 0;
            LblWelcome.Text = mensaje;
            CambiarTema(Tema);
        }

        #region Eventos
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
            BtnConsultar.Visible = false;
        }

        private void DtgvCitas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtgvCitas.Rows[0].Selected = false;
        }

        private void FrmListadoPacientes_Load(object sender, EventArgs e)
        {
            CargarMedicos();
            DtgStyle();
            Deseleccionar();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmListadoPrueba frm = new FrmListadoPrueba("", 'B');
                frm.IdPacientes = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[7].Value.ToString());
                frm.IdDoctor = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[8].Value.ToString());
                frm.IdCitas = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[0].Value.ToString());
                frm.IsOnCitas = true;
                this.Hide();
                frm.ShowDialog();
                CargarMedicos();
                Deseleccionar();
                this.Show();
                BtnConsultar.Click -= new EventHandler(BtnConsultarResultados_Click);
                BtnConsultar.Click -= new EventHandler(BtnVerResultados_Click);
                BtnConsultar.Click -= new EventHandler(BtnConsultar_Click);
            }
            catch (Exception ex)
            {
            }
            
        }
        private void BtnConsultarResultados_Click(object sender, EventArgs e)
        {
            try
            {
                FrmListadosResultados frm = new FrmListadosResultados("", 'B');
                frm.IdPacientes = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[7].Value.ToString());
                frm.IdCitas = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[0].Value.ToString());
                frm.IsOnCitas = true;
                this.Hide();
                frm.ShowDialog();
                CargarMedicos();
                Deseleccionar();
                this.Show();
                BtnConsultar.Click -= new EventHandler(BtnConsultarResultados_Click);
                BtnConsultar.Click -= new EventHandler(BtnVerResultados_Click);
                BtnConsultar.Click -= new EventHandler(BtnConsultar_Click);
            }
            catch (Exception ex)
            {
            }

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmListadoPacientes frm = new FrmListadoPacientes("", 'B');
            frm.IsOnCitas = true;
            this.Hide();
            frm.ShowDialog();
            CargarMedicos();
            Deseleccionar();
            this.Show();
        }

        private void btnClaro_Click(object sender, EventArgs e)
        {
            CambiarTema(BlackAndLight);
        }
        private void BtnVerResultados_Click(object sender, EventArgs e)
        {
            try
            {
                FrmListadoCompletado frm = new FrmListadoCompletado('L');
                frm.IdPacientes = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[7].Value.ToString());
                frm.IdCitas = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[0].Value.ToString());
                frm.NombreDoctor = DtgvCitas.CurrentRow.Cells[2].Value.ToString();
                this.Hide();
                frm.ShowDialog();
                CargarMedicos();
                Deseleccionar();
                this.Show();

                BtnConsultar.Click -= new EventHandler(BtnConsultarResultados_Click);
                BtnConsultar.Click -= new EventHandler(BtnVerResultados_Click);
                BtnConsultar.Click -= new EventHandler(BtnConsultar_Click);
            }
            catch (Exception ex)
            {
            }

        }
        public void DgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                Eventos();
                btnDeseleccionar.Visible = true;
                BtnConsultar.Visible = true;
            }
        }

        #endregion

        #region Metodos

        private void Eventos()
        {

            if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 1)
            {
                BtnConsultar.Text = "           Consultar";
                BtnConsultar.Click -= new EventHandler(BtnConsultarResultados_Click);
                BtnConsultar.Click -= new EventHandler(BtnVerResultados_Click);
                BtnConsultar.Click += new EventHandler(BtnConsultar_Click);
                if (BlackAndLight == 'L')
                {
                    BtnConsultar.ForeColor = Color.Black;
                    BtnConsultar.Image = Properties.Resources.consultar_white;
                }
                else
                {
                    BtnConsultar.ForeColor = Color.White;
                    BtnConsultar.Image = Properties.Resources.consultar_black;
                }
            }
            else if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 2)
            {
                BtnConsultar.Text = "               Consultar                   Resultados";
                BtnConsultar.Click -= new EventHandler(BtnConsultar_Click);
                BtnConsultar.Click -= new EventHandler(BtnVerResultados_Click);
                BtnConsultar.Click += new EventHandler(BtnConsultarResultados_Click);
                if (BlackAndLight == 'L')
                {
                    BtnConsultar.ForeColor = Color.Black;
                    BtnConsultar.Image = Properties.Resources.consultarresultado_white;
                }
                else
                {
                    BtnConsultar.ForeColor = Color.White;
                    BtnConsultar.Image = Properties.Resources.consultarresultado_black;
                }
            }
            else if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 3)
            {
                BtnConsultar.Text = "                Ver                                Resultados";
                BtnConsultar.Click -= new EventHandler(BtnConsultar_Click);
                BtnConsultar.Click -= new EventHandler(BtnConsultarResultados_Click);
                BtnConsultar.Click += new EventHandler(BtnVerResultados_Click);
                if (BlackAndLight == 'L')
                {
                    BtnConsultar.ForeColor = Color.Black;
                    BtnConsultar.Image = Properties.Resources.verresultado_white;
                }
                else
                {
                    BtnConsultar.ForeColor = Color.White;
                    BtnConsultar.Image = Properties.Resources.verresultado_black;
                }
            }
        }
        private void DtgStyle()
        {
            DtgvCitas.Columns[0].Width = 70;
            DtgvCitas.Columns[7].Visible = false;
            DtgvCitas.Columns[8].Visible = false;
            DtgvCitas.Columns[9].Visible = false;
        }
        private void CargarMedicos()
        {

            DtgvCitas.DataSource = _servicioCitas.ListarCitas();
        }

        private void Eliminar()
        {
            if (DtgvCitas.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(DtgvCitas.CurrentRow.Cells[0].Value.ToString());
                if (DialogResult.Yes == MessageBox.Show("Esta seguro que desea eliminar el paciente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    bool result=false;
                    if (result)
                    {
                        MessageBox.Show("El Doctor se ha eliminado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarMedicos();
                        Deseleccionar();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el Doctor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else
            {
                MessageBox.Show("Seleccione una fila", "Notificacion");
            }
        }

        private void Deseleccionar()
        {
            DtgvCitas.ClearSelection();
            BtnConsultar.Visible = false;
            btnDeseleccionar.Visible = false;
        }

        private void CambiarTema(char Tema)
        {
            if (Tema == 'B' || BlackAndLight == 'B')
            {
                BlackAndLight = 'L';
                this.BackColor = Color.White;
                tableLayoutPanel1.BackColor = Color.White;
                btnClaro.Text = "Claro ☼";

                btnAgregar.ForeColor = Color.Black;
                btnEliminar.ForeColor = Color.Black;
                BtnConsultar.ForeColor = Color.Black;
                btnClaro.ForeColor = Color.Black;
                this.ForeColor = Color.Black;
                btnDeseleccionar.ForeColor = Color.Black;

                btnAgregar.Image = Properties.Resources.citas_white;
                btnEliminar.Image = Properties.Resources.citasdelete_white;
                btnDeseleccionar.Image = Properties.Resources.deselect_white;

                try
                {
                    if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 1)
                    {
                        BtnConsultar.Image = Properties.Resources.consultar_white;
                    }
                    else if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 2)
                    {
                        BtnConsultar.Image = Properties.Resources.consultarresultado_white;
                    }
                    else if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 3)
                    {
                        BtnConsultar.Image = Properties.Resources.verresultado_white;
                    }
                    else
                    {
                        BtnConsultar.Image = Properties.Resources.consultar_white;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                DtgvCitas.DefaultCellStyle.BackColor = Color.White;
                DtgvCitas.DefaultCellStyle.ForeColor = Color.Gray;
                DtgvCitas.BackgroundColor = Color.White;
            }
            else
            {
                BlackAndLight = 'B';
                this.BackColor = Color.FromArgb(26, 32, 40);
                tableLayoutPanel1.BackColor = Color.FromArgb(26, 32, 40);
                btnClaro.Text = "OSCURO 🌙";
                btnAgregar.ForeColor = Color.White;
                btnEliminar.ForeColor = Color.White;
                BtnConsultar.ForeColor = Color.White;
                btnClaro.ForeColor = Color.White;
                btnDeseleccionar.ForeColor = Color.White;
                this.ForeColor = Color.White;

                try
                {
                    if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 1)
                    {
                        BtnConsultar.Image = Properties.Resources.consultar_black;
                    }
                    else if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 2)
                    {
                        BtnConsultar.Image = Properties.Resources.consultarresultado_black;
                    }
                    else if (Convert.ToInt32(DtgvCitas.CurrentRow.Cells[9].Value.ToString()) == 3)
                    {
                        BtnConsultar.Image = Properties.Resources.verresultado_black;
                    }
                    else
                    {
                        BtnConsultar.Image = Properties.Resources.consultar_black;
                    }
                }
                catch (Exception ex)
                {
                }
                btnAgregar.Image = Properties.Resources.citas_black;
                btnEliminar.Image = Properties.Resources.citasdelete_black;
                btnDeseleccionar.Image = Properties.Resources.deselect_black;
                this.ForeColor = Color.White;
                DtgvCitas.DefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
                DtgvCitas.DefaultCellStyle.ForeColor = Color.White;
                DtgvCitas.BackgroundColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));

            }
        }

        #endregion

        private void BtnConsultar_Click_1(object sender, EventArgs e)
        {
        }
    }
}
