using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class DataCitas
    {
        private SqlConnection _conexion;
        public DataCitas(SqlConnection conexion)
        {
            _conexion = conexion;
        }


        public DataTable ListadoCitas()
        {
            SqlCommand comando = new SqlCommand("SP_ListarCitas", _conexion);
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

        public bool AgregarCitas(Citas citas)
        {
            SqlCommand comando = new SqlCommand("SP_AgregarCitas", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdPacientes", citas.IdPacientes);
            comando.Parameters.AddWithValue("@IdDoctor", citas.IdDoctor);
            comando.Parameters.AddWithValue("@Fecha_Cita",citas.Fecha_Cita);
            comando.Parameters.AddWithValue("@Hora_Cita", citas.Hora_Cita);
            comando.Parameters.AddWithValue("@Causa_Cita",citas.Causa);
            comando.Parameters.AddWithValue("@Estado_Citas", citas.Estado_Citas);

            return ExecuteProc(comando);
        }

        public bool ActualizarEstado(Citas citas)
        {
            SqlCommand comando = new SqlCommand("SP_ActualizarEstadoCitas", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", citas.Id);
            comando.Parameters.AddWithValue("@Estado_Cita", citas.Estado_Citas);

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
            catch(Exception ex)
            {
                _conexion.Close();
                return false;
            }
        }
    }
}
