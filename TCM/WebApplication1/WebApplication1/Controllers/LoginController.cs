using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Dados;
using WebApplication1.Models;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
   

    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GerenteLogin()
        {
            return View();
        }



       
        public ActionResult PassageiroLogin()
        {


            return View();
        }


        [HttpPost]          
        public ActionResult ValidaPass(Passageiro p)
        {


            var repLogin = new RepositorioLogin();
            var LOGIN= repLogin.ValidarPassageiro(p);


           
            
                
            if (LOGIN.Count >= 1)
            {
                return RedirectToAction("Index", "Home", "Index");
            }
            else
                return RedirectToAction("");


        }

        public ActionResult MotoristaLogin()
        {
            return View();
        }
    }
}