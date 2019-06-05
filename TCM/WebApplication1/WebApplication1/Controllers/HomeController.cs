using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Dados;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        Banco b = new Banco();
         
        public ActionResult Index()
        {
            var GerenteLista = new AcoesGerente().Listar();


            return View(GerenteLista);

        }


        public ActionResult Alterar()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult Alterar(Passageiro p)
        {
            AcoesGerente g = new AcoesGerente();

           
            g.Atualizar(p);

           

            return View(p);
        }
        




        public ActionResult Inserir()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Passageiro p)
        {
            var g = new AcoesGerente();

            
            g.Insert(p);

            return RedirectToAction("Index");

            

        }

        public ActionResult Deletar()
        {
     

            return View();
        }


        [HttpPost]
        public ActionResult Deletar(Passageiro p)
        {
            var g = new AcoesGerente();

            g.Excluir(p);

            return View();
        }
    }
}