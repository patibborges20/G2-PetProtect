using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G2_PetProtect.Models.Funcionarios;

namespace G2_PetProtect.Controllers
{
    public class FuncionariosController : Controller
    {
          Funcionarios funcionario = new Funcionarios();
        public ActionResult Index()
        {
            List<Funcionarios> Lista = FuncionariosRepositorio.Get("");
          
            return View(Lista);
        }

        public ActionResult AdicionarFuncionario()
        {       
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarFuncionario(Funcionarios pfuncionario)
        {
            if (ModelState.IsValid)
            {
                FuncionariosRepositorio.Create(pfuncionario);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult EditarFuncionario(String pID)
        {
            Funcionarios A = FuncionariosRepositorio.achar(pID);
            return View(A);
        }
       
       [HttpPost]
        public ActionResult EditarFuncionario(Funcionarios A)
        {
            FuncionariosRepositorio.Editar(A);
            return RedirectToAction("Index");
        }


        public ActionResult Deletar(string pID)
        {
           Funcionarios A= FuncionariosRepositorio.achar(pID);
           return View(A);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult DeleteConfirma(string pID)
        {
            Funcionarios A= FuncionariosRepositorio.achar(pID);
            FuncionariosRepositorio.Deletar(A);
            return RedirectToAction("Index");
        }
    }
    }
