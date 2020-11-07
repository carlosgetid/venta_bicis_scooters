﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Venta_Bicis_Scooters.ENTITY
{
    public class Bicicleta
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Aro { get; set; }

        public string Color { get; set; }

        public string Freno { get; set; }

        public string Peso { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public int codMarca { get; set; }
        public int codImg { get; set; }
    }
}