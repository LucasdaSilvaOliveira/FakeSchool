using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FakeSchool.Web.Modules.Aluno.Controllers
{
    [Authorize]
    [Area("Aluno")]
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
