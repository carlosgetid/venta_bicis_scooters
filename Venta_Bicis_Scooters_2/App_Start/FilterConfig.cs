using System.Web;
using System.Web.Mvc;

namespace Venta_Bicis_Scooters_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
