using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Libros
    {
        public string ISBN { get; set; }
        public string nombreLibro { get; set; }
        public string autorLibro { get; set; }
        public decimal precio { get; set; }
        public string fechaPublicacion { get; set; }
        public string rutaFoto { get; set; }
        public string email { get; set; }
    }
}