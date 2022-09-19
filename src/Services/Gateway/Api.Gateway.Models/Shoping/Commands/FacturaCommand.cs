using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Gateway.Models.seeker.Commands
{
    public class FacturaCommand
    {
        public int IdFactura { get; set; }

        public string Observacion { get; set; }

        public double Subtotal { get; set; }

        public double Impuesto { get; set; } 

        public double Total { get; set; }

        public string Fecha { get; set; }


    }
}
