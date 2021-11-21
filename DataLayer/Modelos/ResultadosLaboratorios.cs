using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Modelos
{
    public class ResultadosLaboratorios
    {
        public int Id { get; set; }
        public Medicos Medicos { get; set; }
        public Pacientes Pacientes { get; set; }
        public Citas Citas { get; set; }
        public PruebasLaboratorios PruebasLaboratorios { get; set; }
        public string Estado { get; set; }

    }

}
