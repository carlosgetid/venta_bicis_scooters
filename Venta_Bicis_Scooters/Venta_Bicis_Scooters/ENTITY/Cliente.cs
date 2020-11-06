using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Venta_Bicis_Scooters.ENTITY
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }

        public int CodigoDireccion { get; set; }
        public string Direccion { get; set; }


        public string UsernameCliente { get; set; }
        public string PasswordCliente { get; set; }
        public int EstadoCliente { get; set; }

    }
}