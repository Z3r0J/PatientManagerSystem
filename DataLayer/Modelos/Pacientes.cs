using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Modelos
{
    public class Pacientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Teléfono { get; set; }
        public string Dirección { get; set; }
        public string Cédula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Fumador { get; set; }
        public string Alergias { get; set; }
        public string Foto { get; set; }
    }
}
