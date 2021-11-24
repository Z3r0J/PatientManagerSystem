using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using DataLayer.Modelos;

namespace BusinessLayer
{
    public class ServiceCitas
    {
        DataCitas citas;
        public ServiceCitas(SqlConnection conexion)
        {
            citas = new DataCitas(conexion);
        }

        public DataTable ListarCitas()
        {
            return citas.ListadoCitas();
        }


        public bool AgregarCitas(Citas Citas)
        {
            return citas.AgregarCitas(Citas);
        }
    }
}
