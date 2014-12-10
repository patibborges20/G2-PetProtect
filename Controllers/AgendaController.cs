using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G2_PetProtect.Models.Agenda;
using G2_PetProtect.Models.Pets;
using G2_PetProtect.Models.Servicos;
using G2_PetProtect.Models.Funcionarios;
using G2_PetProtect.Models.Horarios;


namespace G2_PetProtect.Controllers
{
    public class AgendaController : Controller
    {
           AgendaRepositorio agendinha  = new AgendaRepositorio();
        public ActionResult Index()
        {            
            return View(AgendaRepositorio.Get(""));
        }

        public ActionResult Adicionar()
        {

            ViewBag.vPets = new SelectList(PetsRepositorio.Get(), "idPet", "nomePet");
            ViewBag.vServicos = new SelectList(ServicosRepositorio.Get(string.Empty), "idServico", "nomeServico");
            ViewBag.vFuncionarios = new SelectList(FuncionariosRepositorio.Get(string.Empty), "idFuncionario", "nomeFuncionario");
            ViewBag.vHorarios = new SelectList(HorariosRepositorio.Get(), "idHorario", "Horario");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Agenda pAgenda)
        {
            agendinha.Create(pAgenda);
            return RedirectToAction("Index");
        }

        public ActionResult Deletar(string pID)
        {
            Agenda A = AgendaRepositorio.achar(pID);
            return View(A);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult DeleteConfirma(string pID)
        {
            Agenda A = AgendaRepositorio.achar(pID);
            AgendaRepositorio.Deletar(A);
            return RedirectToAction("Index");
        }

        public ActionResult EditarAgenda(String pID)
        {
            ViewBag.vPets = new SelectList(PetsRepositorio.Get(), "idPet", "nomePet");
            ViewBag.vServicos = new SelectList(ServicosRepositorio.Get(string.Empty), "idServico", "nomeServico");
            ViewBag.vFuncionarios = new SelectList(FuncionariosRepositorio.Get(string.Empty), "idFuncionario", "nomeFuncionario");
            ViewBag.vHorarios = new SelectList(HorariosRepositorio.Get(), "idHorario", "horario");
            Agenda A = AgendaRepositorio.achar(pID);
            return View(A);
        }

        [HttpPost]
        public ActionResult EditarAgenda(Agenda A)
        {
            AgendaRepositorio.Editar(A);
            return RedirectToAction("Index");
        }

    }
    }