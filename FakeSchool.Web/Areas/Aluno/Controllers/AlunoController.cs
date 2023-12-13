using AutoMapper;
using FakeSchool.Infra.Data;
using FakeSchool.Infra.Repositorios.AlunoRepo;
using FakeSchool.Web.Areas.Aluno.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FakeSchool.Web.Modules.Aluno.Controllers
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
                Notas = x.Notas,
                AnoLetivo = x.AnoLetivo,
                Nome = x.Nome,
                Status = x.Status,
                Turma = x.Turma
            }).ToList();

            return View(model);
        }
    }
}
