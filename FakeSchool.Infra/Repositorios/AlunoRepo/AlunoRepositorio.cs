using FakeSchool.Domain.Escola;
using FakeSchool.Infra.Repositorios.AlunoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Infra.Repositorios.AlunoRepo
{
    public class AlunoRepositorio : IAlunoRepositorio<Aluno>
    {
        public Aluno ObterPorId()
        {
            throw new NotImplementedException();
        }
    }
}
