using AutoMapper;
using AutoMapper;
using FakeSchool.Domain.Escola;
using FakeSchool.Infra.Repositorios.AlunoRepo;
using FakeSchool.Infra.Repositorios.CursoRepo;
using FakeSchool.Web.Areas.Aluno.Models;
using FakeSchool.Web.Areas.Curso.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FakeSchool.Web.Areas.Aluno.Controllers
{
    [Authorize]
    [Area("Aluno")]
    public class AlunoController : Controller
    {
        private IAlunoRepositorio _alunoRepositorio;
        private ICursoRepositorio _cursoRepositorio;
        private IMapper _mapper;
        public AlunoController(IAlunoRepositorio alunoRepositorio, IMapper mapper, ICursoRepositorio cursoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
            _mapper = mapper;
            _cursoRepositorio = cursoRepositorio;
        }
        public IActionResult Index()
        {
            var alunos = _alunoRepositorio.ObterTodos();
            var model = alunos.Select(x => new AlunoViewModel
            {
                Id = x.Id,
                AnoLetivo = x.AnoLetivo,
                Nome = x.Nome,
                Status = x.Status,
                Curso = x.Curso.Nome
            }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new FormAlunoViewModel();
            PreencherViewBagCursos();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormAlunoViewModel aluno)
        {

            if (ModelState.IsValid)
            {
                var alunoMap = _mapper.Map<FakeSchool.Domain.Escola.Aluno>(aluno);
                _alunoRepositorio.CadastrarAluno(alunoMap);

                TempData["sucesso"] = "Aluno cadastrado com sucesso!";

                return RedirectToAction("Index", "Aluno");
            }

            PreencherViewBagCursos();
            return View(aluno);
        }

        public IActionResult Edit(int id)
        {
            var aluno = _alunoRepositorio.ObterPorId(id);

            var model = _mapper.Map<FormAlunoViewModel>(aluno);
            PreencherViewBagCursos();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FormAlunoViewModel aluno)
        {
            if (ModelState.IsValid)
            {
                if(aluno.AnoLetivo <= aluno.DuracaoAnos)
                {
                    aluno.Status = "Cursando";
                }
                var alunoMap = _mapper.Map<FakeSchool.Domain.Escola.Aluno>(aluno);
                _alunoRepositorio.Atualizar(alunoMap);

                return RedirectToAction("Index", "Aluno");
            }
            PreencherViewBagCursos();
            return View(aluno);
        }

        public IActionResult Delete(int id)
        {
            var aluno = _alunoRepositorio.ObterPorId(id);
            var model = _mapper.Map<AlunoViewModel>(aluno);

            return View(model);
        }

        [ActionName("DeleteConfirmed")]
        public IActionResult Delete(AlunoViewModel aluno)
        {
            _alunoRepositorio.Deletar(aluno.Id);

            return RedirectToAction("Index", "Aluno");
        }

        public IActionResult Gerir(int id)
        {
            var aluno = _alunoRepositorio.ObterPorId(id);

            var model = _mapper.Map<GerirAlunoViewModel>(aluno);

            return View(model);
        }

        public IActionResult Aprovar(int id)
        {
            var aluno = _alunoRepositorio.ObterPorId(id);
            var model = _mapper.Map<GerirAlunoViewModel>(aluno);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aprovar(GerirAlunoViewModel aluno)
        {
            aluno.AnoLetivo++;
            var alunoMap = _mapper.Map<FakeSchool.Domain.Escola.Aluno>(aluno);
            _alunoRepositorio.Atualizar(alunoMap);
            return RedirectToAction("Index", "Aluno");
        }

        public IActionResult Formar(int id)
        {
            var aluno = _alunoRepositorio.ObterPorId(id);
            var model = _mapper.Map<GerirAlunoViewModel>(aluno);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Formar(GerirAlunoViewModel aluno)
        {
            aluno.AnoLetivo++;
            aluno.Status = "Formado";
            var alunoMap = _mapper.Map<FakeSchool.Domain.Escola.Aluno>(aluno);
            _alunoRepositorio.Atualizar(alunoMap);
            return RedirectToAction("Index", "Aluno");
        }
        private void PreencherViewBagCursos()
        {
            var cursos = _cursoRepositorio.ObterTodos();

            var cursosMap = cursos.Select(x => new SelectListItem
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.Cursos = cursosMap;
        }
    }
}
