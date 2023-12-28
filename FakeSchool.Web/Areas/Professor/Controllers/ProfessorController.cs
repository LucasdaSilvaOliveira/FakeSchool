using AutoMapper;
using FakeSchool.Infra.Data;
using FakeSchool.Web.Areas.Professor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FakeSchool.Web.Areas.Professor.Controllers
{
    [Authorize]
    [Area("Professor")]
    public class ProfessorController : Controller
    {
        private BancoContext _bancoContext;
        private IMapper _mapper;
        public ProfessorController(BancoContext bancoContext, IMapper mapper)
        {
            _bancoContext = bancoContext;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
           
            var model = _bancoContext.Professores.Select(x => new ProfessorViewModel
            {
                Id = x.Id,
                Nome = x.Nome
            }).ToList();
            

            return View(model);
        }
    }
}
