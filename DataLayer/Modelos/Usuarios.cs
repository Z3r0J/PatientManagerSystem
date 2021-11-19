using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Modelos
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int TipoDeUsuario { get; set; }

    }
}
