using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Personas
    {
        public string nombreCompleto { get; set; }
        public string email { get; set; }
        public string pais { get; set; }
        public string provincia { get; set; }
        public string direccion { get; set; }
        public string codigoPostal { get; set; }
    }
}