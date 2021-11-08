using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Web.Controllers
{
    public class PersonaController : Controller
    {
        // GET: PersonaController
        public ActionResult PersonaIndex()
        {
            PersonaLogic pl = new PersonaLogic();
            return View(pl.GetAll());
        }

        // GET: PersonaController/Create
        public ActionResult PersonaCreate()
        {
            return View(new Persona());
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonaCreate(Persona per)
        {
            PersonaLogic pl = new PersonaLogic();
            pl.Save(per);
            return RedirectToAction("PersonaIndex");
        }

        // GET: PersonaController/Edit/5
        public ActionResult PersonaEdit(int id)
        {
            PersonaLogic pl = new PersonaLogic();
            return View(pl.GetOne(id));
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonaEdit(Persona per)
        {
            PersonaLogic pl = new PersonaLogic();
            per.State = BusinessEntity.States.Modified;
            pl.Save(per);
            return RedirectToAction("PersonaIndex");
        }

        // GET: PersonaController/Delete/5
        public ActionResult PersonaDelete(int id)
        {
            PersonaLogic pl = new PersonaLogic();
            return View(pl.GetOne(id));
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonaDelete(int id, IFormCollection collection)
        {
            PersonaLogic pl = new PersonaLogic();
            pl.Delete(id);
            return RedirectToAction("PersonaIndex");
        }
    }
}
