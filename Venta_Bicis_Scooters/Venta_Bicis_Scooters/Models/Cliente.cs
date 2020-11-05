using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Venta_Bicis_Scooters.Models
{
    public class Cliente
    {
        public int CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string DNICliente { get; set; }
        public string CorreoCliente { get; set; }
        public string CelularCliente { get; set; }
        public int CodigoDireccion { get; set; }
        public string UsernameCliente { get; set; }
        public string PasswordCliente { get; set; }
        public int EstadoCliente { get; set; }
    }
}