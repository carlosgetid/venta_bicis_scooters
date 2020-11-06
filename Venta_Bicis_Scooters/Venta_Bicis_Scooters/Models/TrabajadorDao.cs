using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Venta_Bicis_Scooters.DATABASE;
using Venta_Bicis_Scooters.ENTITY;
using Venta_Bicis_Scooters.SERVICE;


namespace Venta_Bicis_Scooters.Models
{
    public class TrabajadorDao : ITrabajadorDao<Trabajador>
    {
        public int BuscarTrabajador(int codigo)
        {
            int salida = -1;
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("",cn);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return salida;
        }

        public int UpdateTrabajador(Trabajador t)
        {
            throw new NotImplementedException();
        }
    }
}