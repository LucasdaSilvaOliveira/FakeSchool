using AutoMapper;
using FakeSchool.Infra.Repositorios.CursoRepo;
using FakeSchool.Web.Areas.Curso.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FakeSchool.Web.Areas.Curso.Controllers
{
    [Authorize]
    [Area("Curso")]
    public class CursoController : Controller
    {
        private ICursoRepositorio _cursoRepositorio;
        private IMapper _mapper;
        public CursoController(ICursoRepositorio cursoRepositorio, IMapper mapper)
        {
            _cursoRepositorio = cursoRepositorio;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var cursos = _cursoRepositorio.ObterTodos();

            var model = cursos.Select(x => new CursoViewModel
            {
                Id = x.Id,
                DuracaoAnos = x.DuracaoAnos,
                Nome = x.Nome
            }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new FormCursoViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormCursoViewModel curso)
        {
            if (ModelState.IsValid)
            {
                var cursoMap = _mapper.Map<FakeSchool.Domain.Escola.Curso>(curso);
                _cursoRepositorio.CadastrarCurso(cursoMap);
                return RedirectToAction("Index", "Curso");
            }

            return View(curso);
        }
    }
}
