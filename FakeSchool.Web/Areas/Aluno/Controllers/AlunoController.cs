using AutoMapper;
using FakeSchool.Infra.Repositorios.AlunoRepo;
using FakeSchool.Web.Areas.Aluno.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FakeSchool.Web.Areas.Aluno.Controllers
{
    [Authorize]
    [Area("Aluno")]
    public class AlunoController : Controller
    {
        private IAlunoRepositorio _alunoRepositorio;
        private IMapper _mapper;
        public AlunoController(IAlunoRepositorio alunoRepositorio, IMapper mapper)
        {
            _alunoRepositorio = alunoRepositorio;
            _mapper = mapper;
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
                Turma = x.Turma
            }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new FormAlunoViewModel();
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

                return RedirectToAction("Index", "Aluno");
            }
        
            return View(aluno);
        }

        public IActionResult Edit(int id)
        {
            var aluno = _alunoRepositorio.ObterPorId(id);

            var model = _mapper.Map<FormAlunoViewModel>(aluno);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FormAlunoViewModel aluno)
        {
            if (ModelState.IsValid)
            {
                var alunoMap = _mapper.Map<FakeSchool.Domain.Escola.Aluno>(aluno);
                _alunoRepositorio.Atualizar(alunoMap);

                return RedirectToAction("Index", "Aluno");
            }
            return View(aluno);
        }
    }
}
