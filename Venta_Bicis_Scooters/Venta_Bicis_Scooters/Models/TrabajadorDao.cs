using System;
using System.Collections.Generic;
using System.Data;
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
        public int BuscarTrabajador(string user, string pass)
        {
            int salida = -1;
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Trabajador_Buscar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", user);
                cmd.Parameters.AddWithValue("@password", pass);
                System.Diagnostics.Debug.WriteLine("+++++++++232123123+++++++++++++++++++");
                System.Diagnostics.Debug.WriteLine("+++++++++++++123213+++++++++++++++");

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Trabajador trabajador = new Trabajador();

                    trabajador.Nombre = dr[0].ToString();
                        trabajador.Apellido = dr[1].ToString();
                    trabajador.DNI = dr[3].ToString();
                    trabajador.Correo = dr[4].ToString();
                    trabajador.Celular = dr[5].ToString();
                    trabajador.PasswordTrabajador = dr[6].ToString();

                    salida = 1;
                    System.Diagnostics.Debug.WriteLine("............................");
                    System.Diagnostics.Debug.WriteLine(salida);
                    System.Diagnostics.Debug.WriteLine(salida);
                    System.Diagnostics.Debug.WriteLine(salida);
                }
                dr.Close();
                cn.Close();
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