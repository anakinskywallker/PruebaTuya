using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Api.Gateway.Models.seeker.Commands
{
    public class DataRequest
    {
        
     
        public IDataUser DataUser { get; set; }
        public IDataCompani DataCompani { get; set; }
        public ICollection<IProducts> Products { get; set; }
  
        public string valores { get; set; }


}
    [Serializable]
    public class IDataUser
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }

    }

    [Serializable]
    public class IDataCompani
    {
        public string idCompani { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }
        public string telefono { get; set; }
        public string ciudad { get; set; }
        public long numFactura { get; set; }
        public string observacion { get; set; }
        public string fechaFactura { get; set; }

    }

    [Serializable]
    public class IProducts
    {
        public int idProducto{ get; set; }
        public string descripcion { get; set; }
        public decimal valor_unidad { get; set; }
        public int cantidad { get; set; }
        public decimal impuesto { get; set; }
        public decimal descuento { get; set; }
       
    }


}
