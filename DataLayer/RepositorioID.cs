using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public sealed class RepositorioID
    {

        public static RepositorioID Instancia { get; } = new RepositorioID();

        public decimal Id { get; set; }
        private RepositorioID()
        {

        }
    }
}
