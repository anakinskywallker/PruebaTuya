using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturas.Api.Models
{
    public class Facturas
    {
           [Key]

            public int IdFactura { get; set; }

            public string Observacion { get; set; }

            public decimal Subtotal { get; set; }

            public int Impuesto { get; set; }

            public decimal Total { get; set; }

            public string Fecha { get; set; }


         
    }
}
