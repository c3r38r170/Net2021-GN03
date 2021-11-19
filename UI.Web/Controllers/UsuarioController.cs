using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;
using Business.Logic;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult UsuarioIndex()
        {
            UsuarioLogic ul = new UsuarioLogic();
            return View(ul.GetAll());
        }

        // GET: UsuarioController/Create
        public ActionResult UsuarioCreate()
        {
            return View(new Business.Entities.Usuario());
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuarioCreate(Usuario usu)
        {
            UsuarioLogic ul = new UsuarioLogic();
            usu.PersonaAsociada = ((new PersonaLogic()).GetOne(usu.ID_Persona));
            ul.Save(usu);
            return RedirectToAction("UsuarioIndex");
        }

        // GET: UsuarioController/Edit/5
        public ActionResult UsuarioEdit(int id)
        {
            UsuarioLogic ul = new UsuarioLogic();
            return View(ul.GetOne(id));
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuarioEdit(Usuario usu) {
			if(!string.IsNullOrWhiteSpace(usu.Nombre)
				&& !string.IsNullOrWhiteSpace(usu.Apellido)
				&& !string.IsNullOrWhiteSpace(usu.NombreUsuario)
				&& !string.IsNullOrWhiteSpace(usu.Clave)
				&& usu.Clave.Length>=8
				&& usu.Email != null
				&& UsuarioLogic.ComprobarFormatoEmail(usu.Email.Trim())) {

				usu.Nombre = usu.Nombre.Trim();
				usu.Apellido = usu.Apellido.Trim();
				usu.NombreUsuario = usu.NombreUsuario.Trim();
				usu.Clave = usu.Clave.Trim();
				usu.Email = usu.Email.Trim();
				UsuarioLogic ul = new UsuarioLogic();
				var usuOriginal = ul.GetOne(usu.ID);
				usu.ID_Persona = usuOriginal.ID_Persona;
				usu.PersonaAsociada = usuOriginal.PersonaAsociada;
				usu.State = BusinessEntity.States.Modified;
				ul.Save(usu);
				return RedirectToAction("UsuarioIndex");
			} else {
				usu.State = BusinessEntity.States.Unmodified;
				return View(usu);
			}
        }

        // GET: UsuarioController/Delete/5
        public ActionResult UsuarioDelete(int id)
        {
            UsuarioLogic ul = new UsuarioLogic();
            return View(ul.GetOne(id));
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuarioDelete(int id, IFormCollection collection)
        {
            UsuarioLogic ul = new UsuarioLogic();
            ul.Delete(id);
            return RedirectToAction("UsuarioIndex");
        }
    }
}
