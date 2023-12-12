using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeSchool.Domain.Escola;

namespace FakeSchool.Infra.Repositorios.AlunoRepo
{
    public interface IAlunoRepositorio<Aluno>
    {
        Aluno ObterPorId(int id);
    }
}
