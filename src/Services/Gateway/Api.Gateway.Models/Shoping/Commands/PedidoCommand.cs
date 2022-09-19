using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Gateway.Models.seeker.Commands
{
    public class PedidoCommand
    {
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public int idCliente { get; set; }
        public string observacion { get; set; }
        public string direccion { get; set; }
        public int cantidad { get; set; }
        public string estado { get; set; }
    }
}
