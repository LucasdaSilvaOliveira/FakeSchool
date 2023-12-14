using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeSchool.Domain.Escola;

namespace FakeSchool.Infra.Repositorios.CursoRepo
{
    public interface ICursoRepositorio
    {
        Curso ObterPorId(int id);
        List<Curso> ObterTodos();
        void Atualizar(Curso curso);
        void Deletar(int id);
        void CadastrarCurso(Curso curso);
    }
}
