using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using iText.Layout;
using iText.Kernel.Pdf;
using iText.Html2pdf;
using iText.Kernel.Geom;

namespace PatientManagerSystem
{
    public partial class FrmReportePrueba : Form
    {
        public int IdPacientes { get; set; }
        public int IdCitas { get; set; }
        public FrmReportePrueba()
        {
            InitializeComponent();
        }


        private void ExportarPDF()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));



            //string PaginaHTML_Texto = "<table border=\"1\"><tr><td>HOLA MUNDO</td></tr></table>";
            string PaginaHTML_Texto = Properties.Resources.Reporte.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NombrePaciente", "JuanJo");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCUMENTO", "");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            string filas = string.Empty;
            decimal total = 0;
            //foreach (DataGridViewRow row in dgvproductos.Rows)
            //{
            //    filas += "<tr>";
            //    filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
            //    filas += "<td>" + row.Cells["Descripcion"].Value.ToString() + "</td>";
            //    filas += "<td>" + row.Cells["PrecioUnitario"].Value.ToString() + "</td>";
            //    filas += "<td>" + row.Cells["Importe"].Value.ToString() + "</td>";
            //    filas += "</tr>";
            //    total += decimal.Parse(row.Cells["Importe"].Value.ToString());
            //}
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", total.ToString());



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

            }
        }
            private void button1_Click(object sender, EventArgs e)
            {
                ExportarPDF();
            }
        }
    }
