using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Venta_Bicis_Scooters.ENTITY;
using Venta_Bicis_Scooters.Models;

namespace Venta_Bicis_Scooters.Controllers
{
    public class HomeController : Controller
    {
        ScooterCrudDao scooterdao = new ScooterCrudDao();
        MarcaDao marcadao = new MarcaDao();
        TrabajadorDao trabajadordao = new TrabajadorDao();


        //VISTA ADMINISTRADOR
        public ActionResult PrincipalAdmin(Trabajador t)
        {
            if(Session["User"] != null)
            {
                return View(t);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        //VISTA DE LOGIN
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult IniciarSesion(string user, string pass)
        {
            Trabajador t = trabajadordao.BuscarTrabajador(user, pass);
            if (t != null)
            {
                Session["User"] = t.UsernameTrabajador.ToString();
                return RedirectToAction("PrincipalAdmin", "Home", t);
            }
            else
            {
                TempData["Error"] = "Usuario y/o contraseña incorrecta";
                return RedirectToAction("Login");
            }
        }



        /*---------------------------------------SCOOTER-------------------------------*/

        public ActionResult ListarScooter()
        {
            return View(scooterdao.ListarScooter().ToList());
        }

        public ActionResult ConsultarScooter(int cod=0, string descripcion=null)
        {
            if (descripcion == null) descripcion = string.Empty;
            if (cod == 0) cod = 1;
            ViewBag.descripcion = descripcion;
            ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
            return View(scooterdao.ConsultaScooter(cod,descripcion));
        }

        

    }
}