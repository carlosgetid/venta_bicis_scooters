using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta_Bicis_Scooters.SERVICE
{
    public interface IClienteCrudDao<T>
    {

        void InsertCliente(T e);
        void UpdateCliente(T e);
        void DeleteCliente(T e);
        T BuscarCliente(int id);


        List<T> ListarCliente(int estado);
        List<T> ListarDireccion();

    }
}
