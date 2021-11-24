using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataLayer.Modelos;

namespace DataLayer
{
   public class DataPruebaLaboratorio
    {
        private SqlConnection _conexion;

        public DataPruebaLaboratorio(SqlConnection conexion)
        {
            _conexion = conexion;
        }

        public bool CrearPrueba(PruebasLaboratorios pruebas)
        {
            SqlCommand cmd = new SqlCommand("SP_CrearPrueba", _conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", pruebas.Nombre);

           return ExecuteProc(cmd);
        }

        public DataTable ObtenerPruebas()
        {
            SqlCommand cmd = new SqlCommand("SP_ObtenerPruebas", _conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            _conexion.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
             dt.Load(dr);
            _conexion.Close();

            return dt;           
        }

        public bool EditarPrueba(PruebasLaboratorios pruebas)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarPrueba", _conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", pruebas.Id);
            cmd.Parameters.AddWithValue("@nombre", pruebas.Nombre);

            return ExecuteProc(cmd);
        }

        public bool EliminarPrueba (int id)
        {
            SqlCommand cmd = new SqlCommand("SP_EliminarPrueba", _conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            return ExecuteProc(cmd);
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
