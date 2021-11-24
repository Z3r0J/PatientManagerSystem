using DataLayer;
using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BusinessLayer
{
    public class ServiceDoctor
    {
        DataDoctor doctor;
        public ServiceDoctor(SqlConnection conexion)
        {
            doctor = new DataDoctor(conexion);
        }

        public DataTable ListarDoctor()
        {
            return doctor.ListarDoctor();
        }
        public DataTable BuscarDoctor(string Buscar)
        {
            return doctor.Buscar(Buscar);
        }
        public bool AgregarDoctor(Medicos medicos)
        {
            return doctor.AgregarDoctor(medicos);
        }
        public bool EditarDoctor(Medicos medicos)
        {
            return doctor.EditarDoctor(medicos);
        }

        public bool EliminarDoctor(int id)
        {
            Medicos medicos = new Medicos()
            {
                Id = id
            };
            return doctor.EliminarMedicos(medicos);
        }
        public bool ActualizarFoto(int id, string destino)
        {
            return doctor.ActualizarFoto(id, destino);
        }

    }
}
