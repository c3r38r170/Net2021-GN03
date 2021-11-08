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
    public class EspecialidadController : Controller
    {
        [HttpGet]
        // GET: EspecialidadController
        public ActionResult EspecialidadIndex()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            return View(el.GetAll());
        }

        // GET: EspecialidadController/Create
        public ActionResult EspecialidadCreate()
        {
            return View(new Especialidad());
        }

        // POST: EspecialidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EspecialidadCreate(Especialidad esp)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(esp);
            return RedirectToAction("EspecialidadIndex");
        }

        // GET: EspecialidadController/Edit/5
        public ActionResult EspecialidadEdit(int id)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            return View(el.GetOne(id));
        }

        // POST: EspecialidadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EspecialidadEdit(Especialidad esp)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            esp.State = BusinessEntity.States.Modified;
            el.Save(esp);
            return RedirectToAction("EspecialidadIndex");
        }

        // GET: EspecialidadController/Delete/5
        public ActionResult EspecialidadDelete(int id)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            return View(el.GetOne(id));
        }

        // POST: EspecialidadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EspecialidadDelete(int id, IFormCollection collection)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            el.Delete(id);
            return RedirectToAction("EspecialidadDelete");
        }
    }
}
