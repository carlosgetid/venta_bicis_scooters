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
    public class AccesorioDao : IAccesorioCrudDao<Accesorio>
    {
        public Accesorio BuscarAccesorio(int id)
        {
            throw new NotImplementedException();
        }

        public List<Accesorio> ConsultaAccesorio(int cod, string descripcion)
        {
            List<Accesorio> lista = new List<Accesorio>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Accesorio_Consultar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_marca", cod);
                cmd.Parameters.AddWithValue("@descp_accesorio", descripcion);


                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Accesorio emp = new Accesorio()
                    {
                        ID = Convert.ToInt32(dr["cod_accesorio"]),
                        Descripcion = dr["descrp_accesorio"].ToString(),
                        Marca = dr["descrp_marca"].ToString(),
                        Color = dr["color_accesorio"].ToString(),
                        Peso = dr["peso_accesorio"].ToString(),
                        Material = dr["material_accesorio"].ToString(),
                        Duracion = dr["duracion_accesorio"].ToString(),
                        Dimension = dr["dimension_accesorio"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_accesorio"]),
                        Stock = Convert.ToInt32(dr["stock_accesorio"])

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

        public void DeleteAccesorio(Accesorio e)
        {
            throw new NotImplementedException();
        }

        public void InsertAccesorio(Accesorio e)
        {
            throw new NotImplementedException();
        }

        public List<Accesorio> ListarAccesorio()
        {
            List<Accesorio> lista = new List<Accesorio>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Accesorio_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Accesorio emp = new Accesorio()
                    {
                        ID = Convert.ToInt32(dr["cod_accesorio"]),
                        Descripcion = dr["descrp_accesorio"].ToString(),
                        Marca = dr["descrp_marca"].ToString(),
                        Color = dr["color_accesorio"].ToString(),
                        Peso = dr["peso_accesorio"].ToString(),
                        Material = dr["material_accesorio"].ToString(),
                        Duracion =dr["duracion_accesorio"].ToString(),
                        Dimension = dr["dimension_accesorio"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_accesorio"]),
                        Stock = Convert.ToInt32(dr["stock_accesorio"])

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

        public void UpdateAccesorio(Accesorio e)
        {
            throw new NotImplementedException();
        }
    
    
    
    
    }
}