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


        /////////////////////////////////////////////////////////////

        //PASSAGEIRO


        public ActionResult Index()
        {
            var GerenteLista = new AcoesGerente().Listar();


            return View(GerenteLista);

        }



        public ActionResult Alterar(Passageiro p )
        {

       

            return View(p);
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


        /////////////////////////////////////////////////////////////

        //Motorista


        public ActionResult ListMot(Motorista p)
        {

            var GerenteLista = new AcoesGerente().ListarMot();

            return View(GerenteLista);
        }



        public ActionResult InserirMot()
        {

            return View();
        }

        [HttpPost]
        public ActionResult InserirMot(Motorista p)
        {
            var g = new AcoesGerente();


            g.InsertMot(p);

            return RedirectToAction("ListMot");



        }

        public ActionResult DetalhesMot(Motorista m)
        {


            return View(m);

        }



        public ActionResult AlterarMot(Motorista m)
        {



            return View(m);
        }


        [HttpPost]
        public ActionResult AlteraMot(Motorista p)
        {
            var g = new AcoesGerente();


            g.AtualizarMot(p);



            return RedirectToAction("ListMot");
        }

        public ActionResult DeletarMot(Motorista m)
        {

            return View(m);
        }

        [HttpPost]
        public ActionResult DeletaMot(Motorista m)
        {
            var g = new AcoesGerente();

            g.ExcluirMot(m);

            return View();
        }


        /////////////////////////////////////////////////////////////

        //ONIBUS

        public ActionResult InserirOni ()
        {

            return View();
        }

        [HttpPost]
        public ActionResult InserirOni(Onibus o)
        {
            var g = new AcoesGerente();
            g.InsertOni(o);

            return View();
        }

        public ActionResult ListOni(Onibus o)
        {
            var g = new AcoesGerente().ListaroNI();


            return View(g);

        }

        public ActionResult AlterarOni(Onibus o)
        {

            return View(o);
        }

        [HttpPost]
        public ActionResult AlteraOni(Onibus o)
        {
            var g = new AcoesGerente();

            g.AtualizarONI(o);


            return View();
        }

        public ActionResult detalhesOni (Onibus o)
        {

            return View(o);
        }


        public ActionResult DeletarOni(Onibus o)
        {

            return View(o);
        }
        [HttpPost]
        public ActionResult DeletaOni(Onibus o)
        {
            var g = new AcoesGerente();

            g.ExcluirOni(o);


            return View();
        }






    }
}