﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Modelos
{
    public class Medicos
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int Cedula { get; set; }
        public string Foto { get; set; }
    }
}
