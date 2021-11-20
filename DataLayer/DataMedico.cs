using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DataPacientes
    {
        private SqlConnection _conexion;

        public DataPacientes(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public bool AgregarPaciente(Pacientes paciente)
        {

            SqlCommand comando = new SqlCommand("SP_AgregarPaciente", _conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", paciente.Id);
            comando.Parameters.AddWithValue("@Nombre", paciente.Nombre);
            comando.Parameters.AddWithValue("@Apellido", paciente.Apellido);
            comando.Parameters.AddWithValue("@Telefono", paciente.Telefono);
            comando.Parameters.AddWithValue("@Direccion", paciente.Direccion);
            comando.Parameters.AddWithValue("@Cedula", paciente.Cedula);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", paciente.FechaNacimiento);
            comando.Parameters.AddWithValue("@Fumador", paciente.Fumador);
            comando.Parameters.AddWithValue("@Alergias", paciente.Alergias);
            comando.Parameters.AddWithValue("@Foto", paciente.Foto);

            return ExecuteProc(comando);
        }

        public DataTable ObtenerPacientes()
        {
            SqlCommand comando = new SqlCommand("SP_ObtenerPacientes", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            _conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            _conexion.Close();
            return dt;
        }

        public bool EliminarPaciente(int Id)
        {
            SqlCommand comando = new SqlCommand("SP_EliminarPaciente", _conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id",Id);
            return ExecuteProc(comando);
        }

        public bool ActualizarPaciente(Pacientes paciente)
        {
            SqlCommand comando = new SqlCommand("SP_ActualizarPaciente", _conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", paciente.Id);
            comando.Parameters.AddWithValue("@Nombre", paciente.Nombre);
            comando.Parameters.AddWithValue("@Apellido", paciente.Apellido);
            comando.Parameters.AddWithValue("@Telefono", paciente.Telefono);
            comando.Parameters.AddWithValue("@Direccion", paciente.Direccion);
            comando.Parameters.AddWithValue("@Cedula", paciente.Cedula);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", paciente.FechaNacimiento);
            comando.Parameters.AddWithValue("@Fumador", paciente.Fumador);
            comando.Parameters.AddWithValue("@Alergias", paciente.Alergias);
            comando.Parameters.AddWithValue("@Foto", paciente.Foto);

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
