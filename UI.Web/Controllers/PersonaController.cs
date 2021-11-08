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

<<<<<<< HEAD
        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            return View();
=======
        // GET: PersonaController/Create
        public ActionResult PersonaCreate()
        {
            return View(new Persona());
>>>>>>> 1e64f281defcecc17b68ca359011ea3c05c66df0
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
=======
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
>>>>>>> 1e64f281defcecc17b68ca359011ea3c05c66df0
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
=======
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
>>>>>>> 1e64f281defcecc17b68ca359011ea3c05c66df0
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
=======
        public ActionResult PersonaDelete(int id, IFormCollection collection)
        {
            PersonaLogic pl = new PersonaLogic();
            pl.Delete(id);
            return RedirectToAction("PersonaIndex");
>>>>>>> 1e64f281defcecc17b68ca359011ea3c05c66df0
        }
    }
}
