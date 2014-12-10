using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G2_PetProtect.Models.Servicos;

namespace G2_PetProtect.Controllers
{
    public class ServicosController : Controller
    {
        Servicos servico = new Servicos();
        public ActionResult Index()
        {
            List<Servicos> Lista = ServicosRepositorio.Get("");

            return View(Lista);
        }

        public ActionResult AdicionarServico()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarServico(Servicos pServico)
        {
            if (ModelState.IsValid)
            {
                ServicosRepositorio.Create(pServico);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult EditarServico(String pID)
        {
            Servicos A = ServicosRepositorio.achar(pID);
            return View(A);
        }

        [HttpPost]
        public ActionResult EditarServico(Servicos A)
        {
            ServicosRepositorio.Editar(A);
            return RedirectToAction("Index");
        }


        public ActionResult Deletar(string pID)
        {
            Servicos A = ServicosRepositorio.achar(pID);
            return View(A);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult DeleteConfirma(string pID)
        {
            Servicos A = ServicosRepositorio.achar(pID);
            ServicosRepositorio.Deletar(A);
            return RedirectToAction("Index");
        }
    }
}