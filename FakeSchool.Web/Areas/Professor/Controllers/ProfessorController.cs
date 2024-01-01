using AutoMapper;
using FakeSchool.Infra.Data;
using FakeSchool.Infra.Repositorios.ProfessorRepo;
using FakeSchool.Web.Areas.Professor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FakeSchool.Web.Areas.Professor.Controllers
{
    [Authorize]
    [Area("Professor")]
    public class ProfessorController : Controller
    {
        private IProfessorRepositorio _professorRepositorio;
        private IMapper _mapper;
        public ProfessorController(BancoContext bancoContext, IMapper mapper, IProfessorRepositorio professorRepositorio)
        {
            _mapper = mapper;
            _professorRepositorio = professorRepositorio;
        }
        public IActionResult Index()
        {

            var listaProfessores = _professorRepositorio.ObterTodos();

            var model = listaProfessores.Select(x => new ProfessorViewModel
            {
                Id = x.Id,
                Nome = x.Nome
            }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new ProfessorViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProfessorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var domain = _mapper.Map<FakeSchool.Domain.Escola.Professor>(model);
                _professorRepositorio.CadastrarProfessor(domain);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var professor = _professorRepositorio.ObterPorId(id);

            var model = _mapper.Map<ProfessorViewModel>(professor);
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(ProfessorViewModel model)
        {
            var professor = _mapper.Map<FakeSchool.Domain.Escola.Professor>(model);

            _professorRepositorio.Deletar(professor.Id);
            return RedirectToAction("Index", "Professor");
        }
    }
}
