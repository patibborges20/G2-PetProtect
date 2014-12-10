using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G2_PetProtect.Models.Pets;

namespace G2_PetProtect.Controllers
{
    public class PetsController : Controller
    {
         Pets pet = new Pets();
        public ActionResult Index()
        {
            List<Pets> Lista = PetsRepositorio.Get("");
          
            return View(Lista);
        }

        public ActionResult AdicionarPet()
        {       
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarPet(Pets ppet)
        {
            if (ModelState.IsValid)
            {
                PetsRepositorio.Create(ppet);
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }
        }

        public ActionResult EditarPet(String pID)
        {
            Pets A = PetsRepositorio.achar(pID);
            return View(A);
        }
       
       [HttpPost]
        public ActionResult EditarPet(Pets A)
        {
            PetsRepositorio.Editar(A);
            return RedirectToAction("Index");
        }


        public ActionResult Deletar(string pID)
        {
           Pets A= PetsRepositorio.achar(pID);
           return View(A);
        }

        [HttpPost, ActionName("Deletar")]
        public ActionResult DeleteConfirma(string pID)
        {
            Pets A= PetsRepositorio.achar(pID);
            PetsRepositorio.Deletar(A);
            return RedirectToAction("Index");
        }
    }
}