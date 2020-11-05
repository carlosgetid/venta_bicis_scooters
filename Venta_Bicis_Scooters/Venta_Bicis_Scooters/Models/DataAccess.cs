using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Venta_Bicis_Scooters.Models
{
    public class DataAccess
    {
        SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["CNX_BD"].ConnectionString);

        public int InsertarCliente(Cliente c)
        {
            int salida = -1;
            SqlCommand cmd = new SqlCommand("usp_Cliente_Insertar", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nom_cliente",c.NombreCliente);
            cmd.Parameters.AddWithValue("@ape_cliente", c.ApellidoCliente);
            cmd.Parameters.AddWithValue("@dni_cliente", c.DNICliente);
            cmd.Parameters.AddWithValue("@correo_cliente", c.CorreoCliente);
            cmd.Parameters.AddWithValue("@cel_cliente", c.CelularCliente);
            cmd.Parameters.AddWithValue("@cod_direccion", c.CodigoDireccion);
            cmd.Parameters.AddWithValue("@username_cliente", c.UsernameCliente);
            cmd.Parameters.AddWithValue("@password_cliente", c.PasswordCliente);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return salida;
        }
    }
}