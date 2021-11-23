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
    public class RegistroNotasController : Controller
    {
        // GET: RegistroNotasController
        public ActionResult RegistroNotasIndex()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            return View(dcl.GetAll());
        }

        // GET: RegistroNotasController/Details/5

        
        // GET: RegistroNotasController/Create
        public ActionResult RegistroNotasCarga(int id)
        {
            return RedirectToAction("InscripcionListar", "AlumnoInscripcion", new { id });
        }

        // POST: RegistroNotasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistroNotasCreate(IFormCollection collection)
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

        // GET: RegistroNotasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistroNotasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: RegistroNotasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistroNotasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        }
    }
}
