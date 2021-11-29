using BusinessLayer;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using iText.Html2pdf;
using System.IO;
using DataLayer.Modelos;
using System.Drawing;

namespace PatientManagerSystem
{
    public partial class FrmListadoCompletado : Form
    {
        ServiceResultadosLab _serviceResultados;
        ServicePacientes _servicePacientes;
        private string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public int IdPacientes { get; set; }
        public string NombreDoctor { get; set; }
        public int IdCitas { get; set; }

        private char BlackAndLight { get; set; } = 'L';
        public FrmListadoCompletado(char Tema)
        {
            InitializeComponent();
            SqlConnection _conexion = new SqlConnection(connectionString);
            _serviceResultados = new ServiceResultadosLab(_conexion);
            _servicePacientes = new ServicePacientes(_conexion);

            CambiarTema(Tema);            
        }
        #region Eventos
        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }
        private void dgvPruebas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnDeseleccionar.Visible = true;
            }

        }
        private void FrmListadoPrueba_Load(object sender, EventArgs e)
        {
            CargarPruebas();

        }
        private void dgvPruebas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtgvListadoCompletados.ClearSelection();
        }

        private void BtnCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnInforme_Click(object sender, EventArgs e)
        {
            ExportarPDF();
        }
        private void btnClaro_Click(object sender, EventArgs e)
        {
            CambiarTema(BlackAndLight);
        }
        #endregion

        #region Metodos
        private void ExportarPDF()
        {
            Pacientes datos = new Pacientes();

            datos = _servicePacientes.ObtenerPacientesPorID(IdPacientes);

            string directorio = @"Pacientes\Resultados\" + $"{IdPacientes}" + "\\";
            CreateDirectory(directorio);

            SaveFileDialog savefile = new SaveFileDialog();

            savefile.InitialDirectory=@"Pacientes\Resultados\"+$"{IdPacientes}"+"\\";
            savefile.FileName = string.Format("{0}.pdf",$"No.{IdCitas}-{datos.Nombre}");

            string PaginaHTML_Texto = Properties.Resources.Reporte.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NombrePaciente", $"{datos.Nombre}");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@Direccion", $"{datos.Direccion}");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@Doctor", NombreDoctor);

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@Cedula", datos.Cedula);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FechaNac", $"{datos.FechaNacimiento}");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@Telefono", datos.Telefono);
            string filas = string.Empty;
            foreach (DataGridViewRow row in DtgvListadoCompletados.Rows)
            {
                filas += "<tr>";
                filas += "<th scope='row'>" + row.Cells["Nombre de la prueba"].Value.ToString() + "</th>";
                filas += "<td>" + row.Cells["Resultado Total"].Value.ToString() + "</td>";
                filas += "</tr>";                
            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@Filas", filas);

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        HtmlConverter.ConvertToPdf(PaginaHTML_Texto, stream);
                    }

                    stream.Close();
                }

                MessageBox.Show("PDF EXPORTADO CORRECTAMENTE!", "Notifación");
            }
        }

        private void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private void CargarPruebas()
        {
            DtgvListadoCompletados.DataSource = _serviceResultados.ListadoResultadoCompletados(IdPacientes, IdCitas);
        }

        private void Deseleccionar()
        {
            DtgvListadoCompletados.ClearSelection();
            DtgvListadoCompletados.CurrentCell = null;
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

                BtnCerrarVentana.ForeColor = Color.Black;
                BtnInforme.ForeColor = Color.Black;
                btnDeseleccionar.ForeColor = Color.Black;
                btnClaro.ForeColor = Color.Black;
                this.ForeColor = Color.Black;

                BtnCerrarVentana.Image = Properties.Resources.close_white;
                btnDeseleccionar.Image = Properties.Resources.deselect_white;
                BtnInforme.Image = Properties.Resources.ExportarPDF_white;

                DtgvListadoCompletados.DefaultCellStyle.BackColor = Color.White;
                DtgvListadoCompletados.DefaultCellStyle.ForeColor = Color.Gray;
                DtgvListadoCompletados.BackgroundColor = Color.White;
            }
            else
            {
                BlackAndLight = 'B';
                this.BackColor = Color.FromArgb(26, 32, 40);
                tableLayoutPanel1.BackColor = Color.FromArgb(26, 32, 40);
                btnClaro.Text = "OSCURO 🌙";
                BtnCerrarVentana.ForeColor = Color.White;
                BtnInforme.ForeColor = Color.White;
                btnDeseleccionar.ForeColor = Color.White;
                btnClaro.ForeColor = Color.White;
                this.ForeColor = Color.White;

                BtnCerrarVentana.Image = Properties.Resources.close_black;
                btnDeseleccionar.Image = Properties.Resources.deselect_black;
                BtnInforme.Image = Properties.Resources.ExportarPDF_black;
                DtgvListadoCompletados.DefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
                DtgvListadoCompletados.DefaultCellStyle.ForeColor = Color.White;
                DtgvListadoCompletados.BackgroundColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            }
        }
        #endregion
    }
}
