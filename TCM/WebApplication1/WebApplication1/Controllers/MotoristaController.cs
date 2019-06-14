using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class MotoristaController : Controller
    {
        
        public ActionResult Index()
        {
            var x = new AcoesMotorista().ListarPas();

            

            return View(x);
        }
    }
}