using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G2_PetProtect.Models.Funcionarios;
using G2_PetProtect.Models.Agenda;

namespace G2_PetProtect.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.vFuncionarios = new SelectList(FuncionariosRepositorio.Get(string.Empty), "idFuncionario", "nomeFuncionario");
            return View();
        }
    [HttpPost]
        public ActionResult Index(Agenda tentativa)
        {
            List<Agenda> busca = AgendaRepositorio.busca(tentativa);
            return RedirectToAction("Buscar", new {objeto = busca});
        }

    public ActionResult Buscar(List<Agenda>Busca)
    {
        return View();
    }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}