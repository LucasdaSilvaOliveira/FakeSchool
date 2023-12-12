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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(UsuarioViewModel user)
		{
			var login = await _usuarioService.Logar(user.UserName, user.Senha);

			if(login)
			{
                return RedirectToAction("Index", "Home");
            }

			return View("Login");
		}

		public IActionResult Cadastro()
		{
			var model = new UsuarioViewModel();
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(UsuarioViewModel user)
		{
			var createAccout = await _usuarioService.CriarConta(user);

			if(createAccout)
			{
				ViewData["Sucesso"] = "Cadastro realizado com sucesso.";
				return View("Login");
			}

			ViewData["Falha"] = "Houve erro ao cadastrar usuário!";
			return RedirectToAction("Cadastro");
		}
	}
}
