using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Tarjetas
    {
        public string nombreTarjeta { get; set; }
        public int cvv {  get; set; }
        public string fechaExpiracion { get; set; }
        public string numeroTarjeta { get; set; }
    }
}