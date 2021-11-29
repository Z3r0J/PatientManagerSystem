using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Modelos
{
    public class ResultadosLaboratorios
    {
        public int Id { get; set; }
        public Medicos Medicos { get; set; } = new Medicos();
        public Pacientes Pacientes { get; set; } = new Pacientes();
        public Citas Citas { get; set; } = new Citas();
        public PruebasLaboratorios PruebasLaboratorios { get; set; } = new PruebasLaboratorios();
        public string Resultados { get; set; }
        public int Estado { get; set; }

    }

}
