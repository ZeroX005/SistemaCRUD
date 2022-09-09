using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCRUD.ADO;
using SistemaCRUD.Filters;

namespace SistemaCRUD.Controllers
{
    [VerifySession]
    public class LoginController : Controller
    {
        private BDCRUDINVENTARIOEntities db = new BDCRUDINVENTARIOEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string usuario, string password)
        {
                {
                    var lst = from d in db.Usuario
                              where d.usuario1 == usuario && d.password == password
                              select d;
                    if (lst.Count()>0)
                    {
                        Usuario oUser = lst.First();
                        Session["User"] = oUser;
                        return RedirectToAction("Index", "Home");
                    }
                    else{
                        ViewData["Mensaje"] = "Usuario no encontrado";
                        return View();
                    }

                }

        }
    }
}