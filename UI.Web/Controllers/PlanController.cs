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
    public class PlanController : Controller
    {
        // GET: PlanController
        [HttpGet]
        public ActionResult PlanIndex()
        {
            PlanLogic pl = new PlanLogic();
            return View(pl.GetAll());
        }

        // GET: PlanController/Create
        public ActionResult PlanCreate()
        {
            return View(new Plan());
        }

        // POST: PlanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlanCreate(Plan pla)
        {
            PlanLogic pl = new PlanLogic();
            pl.Save(pla);
            return RedirectToAction("PlanIndex");
        }

        // GET: PlanController/Edit/5
        public ActionResult PlanEdit(int id)
        {
            PlanLogic pl = new PlanLogic();
            return View(pl.GetOne(id));
        }

        // POST: PlanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlanEdit(Plan pla)
        {
            PlanLogic pl = new PlanLogic();
            pla.State = BusinessEntity.States.Modified;
            pl.Save(pla);
            return RedirectToAction("PlanIndex");
        }

        // GET: PlanController/Delete/5
        public ActionResult PlanDelete(int id)
        {
            PlanLogic pl = new PlanLogic();
            return View(pl.GetOne(id));
        }

        // POST: PlanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlanDelete(int id, IFormCollection collection)
        {
            PlanLogic pl = new PlanLogic();
            pl.Delete(id);
            return RedirectToAction("PlanIndex");
        }
    }
}
