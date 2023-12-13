using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeSchool.Domain.Escola;

namespace FakeSchool.Infra.Repositorios.AlunoRepo
{
    public interface IAlunoRepositorio
    {
        Aluno ObterPorId(int id);
        ICollection<Aluno> ObterTodos();
        void Atualizar(Aluno aluno);
        void Deletar(int id);
    }
}
