using FakeSchool.Domain.Escola;
using FakeSchool.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Infra.Repositorios.ProfessorRepo
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private BancoContext _bancoContext;
        public ProfessorRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public void Atualizar(Professor professor)
        {
            _bancoContext.Professores.Update(professor);
            _bancoContext.SaveChanges();
        }

        public void CadastrarProfessor(Professor professor)
        {
            _bancoContext.Professores.Add(professor);
            _bancoContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            var professor = _bancoContext.Professores.FirstOrDefault(p => p.Id == id);
            _bancoContext.Professores.Remove(professor);
            _bancoContext.SaveChanges();
        }

        public Professor ObterPorId(int id)
        {
            var professor = _bancoContext.Professores.FirstOrDefault(p => p.Id == id);
            return professor;
        }

        public List<Professor> ObterTodos()
        {
            var listaProfessores = _bancoContext.Professores.ToList();

            return listaProfessores;
        }
    }
}
