using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Modelos
{
    public class Citas
    {
        public int Id { get; set; }
        public Pacientes Pacientes { get; set; }
        public Medicos Medicos { get; set; }
        public DateTime Fecha_Cita { get; set; }
        public DateTime Hora_Cita { get; set; }
        public string Causa { get; set; }
        public int Estado_Citas { get; set; }
    }
}
