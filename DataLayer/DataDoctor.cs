using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataLayer.Modelos;

namespace DataLayer
{
    public class DataDoctor
    {
        SqlConnection _conexion;
        public DataDoctor(SqlConnection conexion)
        {
            _conexion = conexion;
        }

        public DataTable Buscar(string Buscar)
        {
            SqlCommand comando = new SqlCommand("SP_BuscarDoctor", _conexion);
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

        public DataTable ListarDoctor()
        {
            SqlCommand comando = new SqlCommand("SP_ListarDoctor", _conexion);
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

        public bool AgregarDoctor(Medicos doctor)
        {

            SqlCommand comando = new SqlCommand("SP_AgregarDoctor", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", doctor.Nombre);
            comando.Parameters.AddWithValue("@Apellido", doctor.Apellido);
            comando.Parameters.AddWithValue("@Correo", doctor.Correo);
            comando.Parameters.AddWithValue("@Telefono", doctor.Telefono);
            comando.Parameters.AddWithValue("@Cedula", doctor.Cedula);
            comando.Parameters.AddWithValue("@Foto", doctor.Foto);

            try
            {
                _conexion.Open();
                comando.ExecuteNonQuery();
                RepositorioID.Instancia.Id = TomarIDInsertado();
                _conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                _conexion.Close();
                return false;
            }
        }

        public bool EditarDoctor(Medicos doctor)
        {
            SqlCommand comando = new SqlCommand("SP_ActualizarDoctor", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", doctor.Id);
            comando.Parameters.AddWithValue("@Nombre", doctor.Nombre);
            comando.Parameters.AddWithValue("@Apellido", doctor.Apellido);
            comando.Parameters.AddWithValue("@Correo", doctor.Correo);
            comando.Parameters.AddWithValue("@Telefono", doctor.Telefono);
            comando.Parameters.AddWithValue("@Cedula", doctor.Cedula);
            comando.Parameters.AddWithValue("@Foto", doctor.Foto);

            return ExecuteProc(comando);
        }

        public bool EliminarMedicos(Medicos doctor)
        {
            SqlCommand comando = new SqlCommand("SP_EliminarDoctor", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", doctor.Id);

            return ExecuteProc(comando);
        }

        public bool ActualizarFoto(int id, string destination)
        {

            SqlCommand command = new SqlCommand("update Medicos set Foto=@foto where Id = @id", _conexion);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@foto", destination);

            return ExecuteProc(command);
        }


        public decimal TomarIDInsertado()
        {

            decimal id;
            SqlCommand comando = new SqlCommand("SELECT @@IDENTITY from Usuarios", _conexion);

            SqlDataReader LeerID = comando.ExecuteReader();

            if (LeerID.Read())
            {
                id = LeerID.IsDBNull(0) ? 0 : LeerID.GetDecimal(0);
                return id;
            }
            else
            {
                return 0;
            }

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
            catch (Exception ex)
            {
                _conexion.Close();
                return false;
            }
        }
    }
}
