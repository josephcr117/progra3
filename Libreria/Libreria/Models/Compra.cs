using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Compra
    {
        public int idCompra { get; set; }
        public string email { get; set; }
        public string ISBN { get; set; }
        public DateTime fechaCompra { get; set; }
        public string nombreLibro { get; set; }
        public decimal precio { get; set; }
    }
}