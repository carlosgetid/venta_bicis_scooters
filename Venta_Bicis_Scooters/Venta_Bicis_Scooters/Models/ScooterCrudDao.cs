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
    public class ScooterCrudDao : IScooterCrudDao<Scooter>
    {
        public Scooter BuscarScooter(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteScooter(Scooter e)
        {
            throw new NotImplementedException();
        }

        public void InsertScooter(Scooter e)
        {
            throw new NotImplementedException();
        }

        public List<Scooter> ListarScooter()
        {
            List<Scooter> lista = new List<Scooter>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Scooter_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Scooter emp = new Scooter()
                    {
                        ID = Convert.ToInt32(dr["cod_scooter"]),
                        Descripcion = dr["descrp_scooter"].ToString(),
                        Marca = dr["descrp_marca"].ToString(),
                        Aro = dr["aro_scooter"].ToString(),
                        Color = dr["color_scooter"].ToString(),
                        Velocidad = dr["velocidad_scooter"].ToString(),
                        Motor = dr["motor_scooter"].ToString(),
                        Freno = dr["freno_scooter"].ToString(),
                        Material = dr["material_scooter"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_scooter"]),
                        Stock = Convert.ToInt32(dr["stock_scooter"])

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

        public void UpdateScooter(Scooter e)
        {
            throw new NotImplementedException();
        }
    }
}