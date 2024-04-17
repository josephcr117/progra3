using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libreria.Models
{
    public class Order
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public decimal TotalAmount { get; set; }
    }
}