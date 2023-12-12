using FakeSchool.Infra.Services.Authentication;
using FakeSchool.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FakeSchool.Web.Controllers
{
	public class UsuarioController : Controller
	{
		private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Cadastro()
		{
			var model = new UsuarioViewModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(UsuarioViewModel model)
		{
			var createAccout = await _usuarioService.Logar(model.UserName, model.Senha);

			if(createAccout)
			{
				return RedirectToAction("Index", "Home");
			}
			return RedirectToAction("Cadastro");
		}
	}
}
