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

        


         
        public ActionResult Index()
        {
            var GerenteLista = new AcoesGerente().Listar();


            return View(GerenteLista);

        }

        
        public ActionResult Alterar(Passageiro passageiro)
        {
            
            return View(passageiro);
        }


        [HttpPost]
        public ActionResult Altera(Passageiro p)
        {
            var g = new AcoesGerente();

           
            g.Atualizar(p);

           

            return RedirectToAction("Index");
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

        
        public ActionResult Deletar(Passageiro p)
        {

                                 
            return View(p);

       }


        
        public ActionResult FimDeletar(Passageiro p)
        {

            var g = new AcoesGerente();

            g.Excluir(p);



            return RedirectToAction("Index");
        }


        public ActionResult Detalhes(Passageiro p)
        {


            return View(p);

        }
    }
}