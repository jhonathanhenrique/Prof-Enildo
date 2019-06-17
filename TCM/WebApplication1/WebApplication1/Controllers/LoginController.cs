using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
        public ActionResult GerenteLogin ()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ValidaGerente(Gerente g)
        {

            var repLogin = new RepositorioLogin();
            var LOGIN = repLogin.ValidarGerente(g);







            if (LOGIN.Count >= 1)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                

                return RedirectToAction("GerenteLogin", "Login");
            }

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
                
                return RedirectToAction("Index", "Passageiro", new { LOGIN[0].id });
            }
            else
                return RedirectToAction("PassageiroLogin", "Login");


        }

        public ActionResult MotoristaLogin(Motorista m)
        {

            


            return View();
        }

        public ActionResult Validamot(Motorista m)
        {




            var repLogin = new RepositorioLogin();
            var LOGIN = repLogin.ValidarMotorista(m);







            if (LOGIN.Count >= 1)
            {

                return RedirectToAction("Index", "Motorista");
            }
            else
                return RedirectToAction("PassageiroLogin", "Login");


        }
    }

        //public ActionResult IndexPassageiro(int id)
        //{
        //    var x = new AcoesPassageiro().Listar(id);

        //    return View(x);
        //}


    }
