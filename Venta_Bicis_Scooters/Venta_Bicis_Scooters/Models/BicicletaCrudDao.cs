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
    public class BicicletaCrudDao : IBicicletaCrudDao<Bicicleta>
    {
        public Bicicleta BuscarBicicleta(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bicicleta> ConsultaBicicleta(int cod, string descripcion)
        {
            throw new NotImplementedException();
        }

        public void DeleteBicicleta(Bicicleta e)
        {
            throw new NotImplementedException();
        }

        public void InsertBicicleta(Bicicleta e)
        {
            throw new NotImplementedException();
        }

        public List<Bicicleta> ListarBicicleta()
        {
            List<Bicicleta> lista = new List<Bicicleta>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Bicicleta_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Bicicleta emp = new Bicicleta()
                    {
                        ID = Convert.ToInt32(dr["cod_bicicleta"]),
                        Descripcion = dr["descrp_bicicleta"].ToString(),
                        Marca = dr["descrp_marca"].ToString(),
                        Aro = dr["aro_bicicleta"].ToString(),
                        Color = dr["color_bicicleta"].ToString(),
                        Freno = dr["freno_bicicleta"].ToString(),
                        Peso = dr["peso_bicicleta"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_bicicleta"]),
                        Stock = Convert.ToInt32(dr["stock_bicicleta"])

                    };
                    lista.Add(emp);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lista;
        }

        public void UpdateBicicleta(Bicicleta e)
        {
            throw new NotImplementedException();
        }
    
    
    
    
    
    }
}