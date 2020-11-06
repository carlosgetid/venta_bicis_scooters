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
    public class ClienteCrudDao : IClienteCrudDao<Cliente>
    {
        public Cliente BuscarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCliente(Cliente e)
        {
            throw new NotImplementedException();
        }


        public void InsertCliente(Cliente e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Cliente_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@nom_cliente", e.Nombre);
                cmd.Parameters.AddWithValue("@ape_cliente", e.Apellido);
                cmd.Parameters.AddWithValue("@dni_cliente", e.DNI);
                cmd.Parameters.AddWithValue("@correo_cliente", e.Correo);
                cmd.Parameters.AddWithValue("@cel_cliente", e.Celular);
                cmd.Parameters.AddWithValue("@cod_direccion", e.CodigoDireccion);
                cmd.Parameters.AddWithValue("@username_cliente", e.UsernameCliente);
                cmd.Parameters.AddWithValue("@password_cliente", e.PasswordCliente);


                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

           
        }


        public List<Cliente> ListarCliente(int estado)
        {
            throw new NotImplementedException();
        }

     

        public void UpdateCliente(Cliente e)
        {
            throw new NotImplementedException();
        }




    }
}