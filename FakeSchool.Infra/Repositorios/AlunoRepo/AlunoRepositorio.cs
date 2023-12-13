using FakeSchool.Domain.Escola;
using FakeSchool.Infra.Data;
using FakeSchool.Infra.Repositorios.AlunoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Infra.Repositorios.AlunoRepo
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private BancoContext _bancoContext;
        public AlunoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public Aluno ObterPorId(int id)
        {
            return _bancoContext.Alunos.FirstOrDefault(x => x.Id == id);
        }

        public List<Aluno> ObterTodos()
        {
            return _bancoContext.Alunos.ToList();
        }
        public void Atualizar(Aluno aluno)
        {
            _bancoContext.Alunos.Update(aluno);
            _bancoContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            
            var aluno = _bancoContext.Alunos.FirstOrDefault(x => x.Id == id);
            _bancoContext.Alunos.Remove(aluno);
            _bancoContext.SaveChanges();
        }

        public void CadastrarAluno(Aluno aluno)
        {
            _bancoContext.Alunos.Add(aluno);
            _bancoContext.SaveChanges();
        }
    }
}
