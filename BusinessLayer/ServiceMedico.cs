using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    class ServicePacientes
    {
        DataPacientes data;

        public ServicePacientes(SqlConnection conexion)
        {
            data = new DataPacientes(conexion);
        }

        public DataTable ObtenerPacientes()
        {
            return data.ObtenerPacientes();

        }

        public bool AgregarPaciente(Pacientes paciente)
        {
            return data.AgregarPaciente(paciente);
        }

        public bool EliminarPaciente(int Id)
        {
            return data.EliminarPaciente(Id);
        }

        public bool ActualizarPaciente(Pacientes paciente)
        {
            return data.ActualizarPaciente(paciente);
        }

    }
}
