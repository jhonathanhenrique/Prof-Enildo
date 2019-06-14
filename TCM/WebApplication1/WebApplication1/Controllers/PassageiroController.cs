using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class PassageiroController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id, Passageiro p)
        {
            


            var x = new AcoesPassageiro();
            

            return View(x.selecionaid(id));
        }

        
        [HttpGet]
        public ActionResult Detalhes (int id)
        {
            var g = new AcoesPassageiro().detalhes(id);

            
 
            
            
            return View(g);
        }
    }
}