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
    public class ComisionController : Controller
    {
        
        // GET: ComisionController
        [HttpGet]
        public ActionResult ComisionIndex()
        {
            ComisionLogic col = new ComisionLogic();
            return View(col.GetAll());
        }


        // GET: ComisionController/Create
        public ActionResult ComisionCreate()
        {
            return View(new Business.Entities.Comision());
        }

        // POST: ComisionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ComisionCreate(Comision comi)
        {
            ComisionLogic col = new ComisionLogic();
            col.Save(comi);
            return RedirectToAction("ComisionIndex");
        }

        // GET: ComisionController/Edit/5
        public ActionResult ComisionEdit(int id)
        {
            ComisionLogic col = new ComisionLogic();
            return View(col.GetOne(id));
        }

        // POST: ComisionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ComisionEdit(Comision comi)
        {
            ComisionLogic col = new ComisionLogic();
            comi.State = BusinessEntity.States.Modified;
            col.Save(comi);
            return RedirectToAction("ComisionIndex");
        }
    }
}
