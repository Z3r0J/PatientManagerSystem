using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class ServicePacientes
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

        public bool EditarPaciente(Pacientes paciente)
        {
            return data.EditarPaciente(paciente);
        }
        public int GetLastId()
        {
            return data.TomarIDInsertado();
        }

        public bool SavePhoto(int id, string destination)
        {
            return data.SavePhoto(id, destination);
        }
        public Pacientes ObtenerPacientesPorID(int ID)
        {
            return data.InformacionPacientesID(ID);
        }

    }
}
