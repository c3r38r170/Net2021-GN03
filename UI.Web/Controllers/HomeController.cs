using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using UI.Web.Models;
using Business.Logic;
using Business.Entities;

namespace UI.Web.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}
		
		public IActionResult Index() {
			return View();
		}

		[HttpPost]
		public IActionResult LogIn(string username, string password) {
			UsuarioLogic ul = new UsuarioLogic();
			Usuario u=ul.LogIn(username,password);
			if (u.ID == 0)
            {
				return Redirect("/?message=Usuario Incorrecto");

			}
            else
            {
				return View(u);
            }
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
