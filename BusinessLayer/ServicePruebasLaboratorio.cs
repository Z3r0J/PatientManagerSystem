using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataLayer.Modelos;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
   public class ServicePruebasLaboratorio
    {
        DataPruebaLaboratorio data;
        public ServicePruebasLaboratorio(SqlConnection conexion)
        {
            data = new DataPruebaLaboratorio(conexion);
        }

        public bool CrearPrueba(PruebasLaboratorios pruebas )
        {
            return data.CrearPrueba(pruebas);
        }

        public DataTable ObtenerPrueba()
        {
            return data.ObtenerPruebas();
        } 
        public bool EditarPrueba(PruebasLaboratorios pruebas)
        {
            return data.EditarPrueba(pruebas);
        }

        public bool EliminarPrueba(int id)
        {
            return data.EliminarPrueba(id);
        }



    }
}
