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
        BicicletaCrudDao bicicletadao = new BicicletaCrudDao();
        AccesorioDao accesoriodao = new AccesorioDao();
        /*----------------------------------------------------------------------------------------------------------------*/

        //VISTA ADMINISTRADOR
        public ActionResult PrincipalAdmin()
        {
            if(Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View();
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
                Session["FirstName"] = t.Nombre.ToString();
                Session["LastName"] = t.Apellido.ToString();
                return RedirectToAction("PrincipalAdmin", "Home");
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
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(scooterdao.ListarScooter().ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult ActualizarScooter()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult ConsultarScooter(int cod=0, string descripcion=null)
        {
            if (descripcion == null) descripcion = string.Empty;
            if (cod == 0) cod = 1;
            ViewBag.descripcion = descripcion;
            ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
            return View(scooterdao.ConsultaScooter(cod,descripcion));
        }



        /*---------------------------------------BICICLETA-------------------------------*/

        public ActionResult ListarBicicleta()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(bicicletadao.ListarBicicleta().ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
         
        }

        //INSERT
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
          
        }
        [HttpPost]
        public ActionResult Create(Bicicleta emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");

                        emp.ID = emp.ID;
                        bicicletadao.InsertBicicleta(emp);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("ListarBicicleta");
                    }

                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        //UPDATE
        public ActionResult Edit(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                Bicicleta emp = bicicletadao.BuscarBicicleta(id);

                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");

                return View(bicicletadao.BuscarBicicleta(id));
            }
            else
            {
                return RedirectToAction("Login");
            }


        }
        [HttpPost]
        public ActionResult Edit(Bicicleta emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");

                        bicicletadao.UpdateBicicleta(emp);

                        return RedirectToAction("ListarBicicleta");
                    }
                    else
                    {
                        return RedirectToAction("ListarBicicleta");
                    }

                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login");
            }


           

        }


        //DETALLES
        public ActionResult Details(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(bicicletadao.BuscarBicicleta(id));
            }
            else
            {
                return RedirectToAction("Login");
            }

         
        }


        public ActionResult ConsultarBicicleta(int cod = 0, string descripcion = null)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                if (descripcion == null) descripcion = string.Empty;
                if (cod == 0) cod = 1;
                ViewBag.descripcion = descripcion;
                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                return View(bicicletadao.ConsultaBicicleta(cod, descripcion));


            }
            else
            {
                return RedirectToAction("Login");
            }


        }



        /*---------------------------------------ACCESORIO-------------------------------*/
        public ActionResult ListarAccesorio()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(accesoriodao.ListarAccesorio().ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
          
        }



        //INSERT
        public ActionResult CreateAccesorio()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public ActionResult CreateAccesorio(Accesorio emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");

                        emp.ID = emp.ID;
                        accesoriodao.InsertAccesorio(emp); 
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("ListarAccesorio");
                    }

                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }




        //UPDATE
        public ActionResult EditAccesorio(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                Accesorio emp = accesoriodao.BuscarAccesorio(id);

                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");

                return View(accesoriodao.BuscarAccesorio(id));
            }
            else
            {
                return RedirectToAction("Login");
            }


        }
        [HttpPost]
        public ActionResult EditAccesorio(Accesorio emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");

                        accesoriodao.UpdateAccesorio(emp);
     

                        return RedirectToAction("ListarAccesorio");
                    }
                    else
                    {
                        return RedirectToAction("ListarAccesorio");
                    }

                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login");
            }




        }


        //DETALLES
        public ActionResult DetailsAccesorio(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(accesoriodao.BuscarAccesorio(id));
            }
            else
            {
                return RedirectToAction("Login");
            }


        }



        public ActionResult ConsultarAccesorio(int cod = 0, string descripcion = null)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                if (descripcion == null) descripcion = string.Empty;
                if (cod == 0) cod = 1;
                ViewBag.descripcion = descripcion;
                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                return View(accesoriodao.ConsultaAccesorio(cod, descripcion));
            }
            else
            {
                return RedirectToAction("Login");
            }

           
        }





    }
}