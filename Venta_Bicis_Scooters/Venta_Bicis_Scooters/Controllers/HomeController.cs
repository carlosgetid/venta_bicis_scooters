using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Venta_Bicis_Scooters.Models;

namespace Venta_Bicis_Scooters.Controllers
{
    public class HomeController : Controller
    {
        ScooterCrudDao scooterdao = new ScooterCrudDao();
        MarcaDao marcadao = new MarcaDao();



        public ActionResult Index()
        {
            return View();
        }
        
        //VISTA ADMINISTRADOR
       public ActionResult PrincipalAdmin()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        /*---------------------------------------SCOOTER-------------------------------*/

        public ActionResult ListarScooter()
        {
            return View(scooterdao.ListarScooter().ToList());
        }






    }
}