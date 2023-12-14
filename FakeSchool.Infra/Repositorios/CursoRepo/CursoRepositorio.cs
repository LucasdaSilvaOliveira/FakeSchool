using FakeSchool.Domain.Escola;
using FakeSchool.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Infra.Repositorios.CursoRepo
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private BancoContext _bancoContext;
        public CursoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public Curso ObterPorId(int id)
        {
            return _bancoContext.Cursos.FirstOrDefault(x => x.Id == id);
        }

        public List<Curso> ObterTodos()
        {
            return _bancoContext.Cursos.ToList();
        }
        public void Atualizar(Curso curso)
        {
            _bancoContext.Cursos.Update(curso);
            _bancoContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            
            var curso = _bancoContext.Cursos.FirstOrDefault(x => x.Id == id);
            _bancoContext.Cursos.Remove(curso);
            _bancoContext.SaveChanges();
        }

        public void CadastrarCurso(Curso curso)
        {
            _bancoContext.Cursos.Add(curso);
            _bancoContext.SaveChanges();
        }
    }
}
