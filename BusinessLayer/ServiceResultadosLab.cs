using DataLayer;
using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BusinessLayer
{
    public class ServiceResultadosLab
    {
        DataResultadoLaboratorio data;
        public ServiceResultadosLab(SqlConnection conexion)
        {
            data = new DataResultadoLaboratorio(conexion);
        }

       public DataTable ListarResultados()
        {
            return data.ListadoResultados();
        }

        public DataTable BuscarResultados(string Buscar)
        {
            return data.Buscar_Resultados(Buscar);
        }

        public bool ReportarResultados(ResultadosLaboratorios resultados)
        {
            return data.ReportarResultados(resultados);
        }
    }
}
