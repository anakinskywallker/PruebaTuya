using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logistica.Api.Models
{
    public class Pedido
    {
        [Key]

        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public int idCliente { get; set; }
        public string observacion { get; set; }
        public string direccion { get; set; }
        public int cantidad { get; set; }
        public string estado { get; set; }
    }
}
