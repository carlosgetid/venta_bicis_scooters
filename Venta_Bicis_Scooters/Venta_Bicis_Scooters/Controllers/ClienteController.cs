using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Venta_Bicis_Scooters.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult PrincipalCliente()
        {
            return View();
        }

    }
}