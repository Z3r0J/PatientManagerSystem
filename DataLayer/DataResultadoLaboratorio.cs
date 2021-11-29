using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class DataResultadoLaboratorio
    {

        private SqlConnection _conexion;
        public DataResultadoLaboratorio(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public DataTable ListadoResultados()
        {

            SqlCommand comando = new SqlCommand("SP_Listar_Resultados", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            _conexion.Open();

            DataTable ListarFilas = new DataTable();
            SqlDataReader Datos = comando.ExecuteReader();
            ListarFilas.Load(Datos);
            Datos.Close();
            Datos.Dispose();
            _conexion.Close();

            return ListarFilas;
        }

        public DataTable ListadoResultadosPacientes(int IdPacientes, int IdCitas)
        {

            SqlCommand comando = new SqlCommand("SP_EstadosPruebas", _conexion);

            comando.CommandType = CommandType.StoredProcedure;
            _conexion.Open();
            comando.Parameters.AddWithValue("@IdPacientes", IdPacientes);
            comando.Parameters.AddWithValue("@IdCitas", IdCitas);
            DataTable ListarFilas = new DataTable();
            SqlDataReader Datos = comando.ExecuteReader();
            ListarFilas.Load(Datos);
            Datos.Close();
            Datos.Dispose();
            _conexion.Close();

            return ListarFilas;
        }

        public DataTable ListadoResultadoCompletados(int IdPacientes, int IdCitas)
        {

            SqlCommand comando = new SqlCommand("SP_ListadoPruebasCompletadas", _conexion);

            comando.CommandType = CommandType.StoredProcedure;
            _conexion.Open();
            comando.Parameters.AddWithValue("@IdPacientes", IdPacientes);
            comando.Parameters.AddWithValue("@IdCitas", IdCitas);
            DataTable ListarFilas = new DataTable();
            SqlDataReader Datos = comando.ExecuteReader();
            ListarFilas.Load(Datos);
            Datos.Close();
            Datos.Dispose();
            _conexion.Close();

            return ListarFilas;
        }

        public DataTable Buscar_Resultados(string Buscar)
        {

            SqlCommand comando = new SqlCommand("SP_Buscar_Resultados", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Buscar", Buscar);
            _conexion.Open();

            DataTable ListarFilas = new DataTable();
            SqlDataReader Datos = comando.ExecuteReader();
            ListarFilas.Load(Datos);
            Datos.Close();
            Datos.Dispose();
            _conexion.Close();

            return ListarFilas;
        }

        public bool ReportarResultados(ResultadosLaboratorios resultados)
        {
            SqlCommand comando = new SqlCommand("SP_ReportarResultados", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", resultados.Id);
            comando.Parameters.AddWithValue("@Resultados", resultados.Resultados);
            comando.Parameters.AddWithValue("@Estados_Resultados", resultados.Estado);

            return ExecuteProc(comando);
        }


        public bool AgregarPruebas(ResultadosLaboratorios resultados)
        {
            SqlCommand comando = new SqlCommand("SP_AgregarResultados", _conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdPacientes",resultados.Pacientes.Id);
            comando.Parameters.AddWithValue("@IdCitas",resultados.Citas.Id);
            comando.Parameters.AddWithValue("@IdPruebas",resultados.PruebasLaboratorios.Id);
            comando.Parameters.AddWithValue("@IdDoctor",resultados.Medicos.Id);
            comando.Parameters.AddWithValue("@Resultados",resultados.Resultados);
            comando.Parameters.AddWithValue("@Estados_Resultados",resultados.Estado);

            return ExecuteProc(comando);
        }

        public bool ExecuteProc(SqlCommand comando)
        {
            try
            {
                _conexion.Open();
                comando.ExecuteNonQuery();
                _conexion.Close();
                return true;
            }
            catch
            {
                _conexion.Close();
                return false;
            }
        }
    }
}
