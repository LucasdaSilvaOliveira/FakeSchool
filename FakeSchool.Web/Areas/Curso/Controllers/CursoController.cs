using AutoMapper;
using FakeSchool.Domain.Escola;
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

        public IActionResult Edit(int id)
        {
            var curso = _cursoRepositorio.ObterPorId(id);

            var model = _mapper.Map<FormCursoViewModel>(curso);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FormCursoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var curso = _mapper.Map<FakeSchool.Domain.Escola.Curso>(model);
                _cursoRepositorio.Atualizar(curso);
                return RedirectToAction("Index", "Curso");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var curso = _cursoRepositorio.ObterPorId(id);

            var model = _mapper.Map<CursoViewModel>(curso);
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(CursoViewModel model)
        {
            _cursoRepositorio.Deletar(model.Id);
            return RedirectToAction("Index", "Curso");
        }
    }
}
