using FakeSchool.Domain.Escola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Infra.Repositorios.ProfessorRepo
{
    public interface IProfessorRepositorio
    {
        List<Professor> ObterTodos();
        Professor ObterPorId(int id);
        void Deletar(int id);
        void Atualizar(Professor professor);
        void CadastrarProfessor(Professor professor);
    }
}
